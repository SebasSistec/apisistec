using apisistec.Constants;
using apisistec.Context;
using apisistec.Dtos;
using apisistec.Dtos.Support;
using apisistec.Entities;
using apisistec.Enums;
using apisistec.Extensions;
using apisistec.Interfaces;
using apisistec.Models.Common;
using apisistec.Models.Parameters;
using apisistec.Models.Parameters.Support;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace apisistec.Services
{
    public class SupportService : ISupportService
    {
        private DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IMediaService _mediaService;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public SupportService(
            DataContext context,
            IMapper mapper,
            IHttpContextAccessor httpContextAccesor,
            IOptions<AppSettings> appSettings,
            IMediaService mediaService)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccesor = httpContextAccesor;
            _appSettings = appSettings.Value;
            _mediaService = mediaService;
        }
        public string GetSuppportToken(string userId, string companyId)
        {
            const string CLAIM_KEY = "companyId";
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret!);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                            new Claim[]
                            {
                                new Claim(CLAIM_KEY, companyId),
                                new Claim(ClaimTypes.NameIdentifier, userId)
                            }),
                Expires = DateTime.Now.AddDays(14),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                                SecurityAlgorithms.HmacSha256Signature
                                                            )
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public CredentialsToken GetUserSupportCredentials()
        {
            CredentialsToken credentials = new();
            credentials.userId = _httpContextAccesor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            credentials.companyId = _httpContextAccesor?.HttpContext?.User?.FindFirst("companyId")?.Value;

            if (string.IsNullOrEmpty(credentials.userId) || string.IsNullOrEmpty(credentials.companyId))
                throw new Exception("Token inválido");
            
            return credentials;
        }

        public IssueCreatedResponseDto CreateSupport(IssueCreateDto create)
        {
            CredentialsToken user = GetUserSupportCredentials();
            string? employeeId = _context.Empleados.Select(x => x.CodigoEmpleado).FirstOrDefault(x => x.Equals(user.userId));
            if (string.IsNullOrEmpty(employeeId))
                throw new Exception("No se encontró su usuario");
            
            int orderNumber = 0;

            if (_context.Issues.Count() > 0)
                orderNumber = _context.Issues.Max(x => x.orderNumber);

            Issues issue = _mapper.Map<Issues>(create);
            issue.orderNumber = orderNumber + 1;
            issue.asignedById = employeeId;

            if(create.details.Count > 0)
            create.details.ForEach(detail =>
            {
                IssueDetails issueDetail = _mapper.Map<IssueDetails>(detail);
                issueDetail.issueId = issue.id;
                _context.IssueDetails.Add(issueDetail);

                IssueTimings timing = _mapper.Map<IssueTimings>(issueDetail);
                timing.employeeId = detail.employee.id;
                _context.IssueTimings.Add(timing);

                detail.cacheFileKeys.ForEach(cache =>
                {
                    IssueFiles file = _mediaService.SaveFileFromTmp(
                                                    PathFolders.IMG_ISSUES,
                                                    issueDetail.id.ToString(),
                                                    cache.tempPath);
                    file.issueDetailId = issueDetail.id;
                    _context.IssueFiles.Add(file);
                });

            });

            List<IssueTimings> timings = _mapper.Map<List<IssueTimings>>(issue.issueDetails);

            _context.Issues.Add(issue);
            _context.IssueTimings.AddRange(timings);

            IssueCreatedResponseDto created = new()
            {
                id = issue.id,
                orderNumber = issue.orderNumber,
            };

            ProjectsPerClients? projectClient = _context.ProjectsPerClients.Where(x =>
                x.ClientId.Equals(create.clientId)
                && x.ProjectId.Equals(create.projectId))
                .FirstOrDefault();

            if (projectClient is null)
            {
                projectClient = new()
                {
                    ClientId = create.clientId,
                    ProjectId = create.projectId
                };

                _context.ProjectsPerClients.Add(projectClient);
            }

            return created;
        }

        public PaginationDto<SupportDto> GetByUser(QueryParams qParams)
        {
            CredentialsToken user = GetUserSupportCredentials();

            IEnumerable<Issues> issues = _context.Issues
                .Include(x => x.client)
                .Include(x => x.asignedBy)
                .Include(x => x.asignedTo)
                .Include(x => x.project)
                .Include(x => x.issueDetails)
                    .ThenInclude(x => x.module)
                .Include(x => x.issueDetails)
                    .ThenInclude(x => x.producto)
                .Include(x => x.issueDetails)
                    .ThenInclude(x => x.files)
                .Include(x => x.issueDetails.Where(detail => detail.timings.All(x => x.employeeId == user.userId)))
                    .ThenInclude(x => x.timings.Where(timing => timing.employeeId == user.userId).OrderByDescending(x => x.createdAt))
                        .ThenInclude(x => x.employee)
                .OrderBy(x => x.createdAt)
                .ToList();

            IEnumerable<SupportDto> supports = _mapper.Map<IEnumerable<SupportDto>>(issues);
            PaginationDto<SupportDto> paged = supports.Where(x => x.details.Count > 0).GetPaged(qParams); 
            return paged;
        }

        public UpdateDetailTimingDto UpdateSupportDetail(UpdateDetailTimingDto detail)
        {
            CredentialsToken user = GetUserSupportCredentials();

            HttpRequest request = _httpContextAccesor.HttpContext.Request;
            string urlBaseImage = request.Host.Host;

            IssueTimings? timing = _context.IssueTimings.Where(x => x.id == detail.id).Include(x => x.detail).FirstOrDefault();
            if(timing is null)
                throw new Exception("No se encontró el pendiente");

            switch (detail.state)
            {
                case IssueStateEnum.STARTED:
                    IssueDetails? support = _context.IssueDetails
                        .Include(x => x.issue)
                        .Where(x => x.timings.Any(x => x.employeeId == user.userId) && x.timings.Any(x => x.state == IssueStateEnum.STARTED))
                        .FirstOrDefault();

                    if(timing.state == IssueStateEnum.PENDING)
                        timing.startAt = DateTime.Now;

                    if (support is not null)
                        throw new Exception($"Ya tiene una orden iniciada #{support.issue.orderNumber}");
                    
                    timing.pauseDescription = string.Empty;

                break;
                case IssueStateEnum.FINISHED:
                    timing.pauseDescription = string.Empty;
                    timing.detail.solution = detail.solution;
                    timing.endAt = DateTime.Now;
                break;
                case IssueStateEnum.PAUSED:
                    timing.pauseDescription = detail.pauseDescription;
                break;
                default:
                break;
            }

            timing.state = detail.state;

            _context.IssueTimings.Update(timing);
            _context.SaveChanges();

            return detail;
        }

        public PaginationDto<SupportDto> GetWithParams(SupportQParams qParams)
        {
            Expression<Func<Issues, bool>> clientsCondition = issue => true;
            Expression<Func<IssueTimings, bool>> employeesCondition = issue => true;
            Expression<Func<IssueDetails, bool>> productsCondition = issue => true;
            Expression<Func<Issues, bool>> proyectsCondition = issue => true;
            Expression<Func<Issues, bool>> orderNumCondition = issue => true;
            Expression<Func<Issues, bool>> priorityCondition = issue => true;
            Expression<Func<IssueDetails, bool>> detailCondition = issue => true;
            Expression<Func<IssueTimings, bool>> detailStateCondition = detail => true;

            if (!string.IsNullOrEmpty(qParams.orderNum))
                orderNumCondition = s => s.orderNumber.ToString() == qParams.orderNum;
            
            if (!string.IsNullOrEmpty(qParams?.priority.ToString()))
                priorityCondition = s => s.priority.Equals(qParams.priority);

            if (qParams?.clients?.Length > 0)
                clientsCondition = s => qParams.clients.Contains(s.clientId);

            if (qParams?.products?.Length > 0)
                productsCondition = s => qParams.products.Contains(s.productId);

            if (!string.IsNullOrEmpty(qParams?.detailState.ToString()))
            {
                detailStateCondition = s => s.state == qParams.detailState;
                detailCondition = detail => detail.timings.Any(timing => timing.state == qParams.detailState);
            }

            if (qParams?.employees?.Length > 0)
            {
                employeesCondition = s => qParams.employees.Contains(s.employeeId);
                detailCondition = detail => detail.timings.All(x => qParams.employees.Contains(x.employeeId));
            }

            if (qParams?.employees?.Length > 0 && !string.IsNullOrEmpty(qParams?.detailState.ToString()))
                detailCondition = detail => detail.timings.Any(timing => timing.state == qParams.detailState) && detail.timings.All(x => qParams.employees.Contains(x.employeeId));

            if (qParams?.projects?.Length > 0)
                proyectsCondition = s => qParams.projects.Contains(s.projectId);

            Expression<Func<Issues, bool>> dateCondition = s => true;
            if (qParams?.minDate != null)
                dateCondition = s => s.createdAt >= qParams.minDate;

            if (qParams?.maxDate != null)
                dateCondition = dateCondition.And(s => s.createdAt <= qParams.maxDate);

            IQueryable<Issues> query = _context.Issues
                .Include(x => x.client)
                .Include(x => x.asignedBy)
                .Include(x => x.asignedTo)
                .Include(x => x.project)
                .Include(x => x.issueDetails)
                    .ThenInclude(x => x.module)
                .Include(x => x.issueDetails)
                    .ThenInclude(x => x.files)
                .Include(x => x.issueDetails)
                    .ThenInclude(x => x.producto)
                .Include(x => x.issueDetails
                    .AsQueryable()
                    .Where(detailCondition)
                    .Where(productsCondition))
                    .ThenInclude(x => x.timings.AsQueryable()
                        .Where(employeesCondition)
                        .Where(detailStateCondition)
                        .OrderByDescending(x => x.createdAt))
                        .ThenInclude(x => x.employee)
                .Where(clientsCondition)
                .Where(proyectsCondition)
                .Where(dateCondition)
                .Where(priorityCondition)
                .Where(orderNumCondition)
                .OrderBy(x => x.createdAt);

            query = query.OrderBy(qParams?.orderBy!, qParams!.isOrderByDescending);
            IEnumerable<SupportDto> supports = _mapper.Map<IEnumerable<SupportDto>>(query.Where(x => x.issueDetails.Count > 0 && x.issueDetails.Any(x => x.timings.Count > 0)));
            PaginationDto<SupportDto> paged = supports.Where(x => x.details.Count > 0).GetPaged(qParams);
            return paged;
        }

        public List<IssueTimingDto> GetTiming(Guid detailId)
        {
            List<IssueTimings> timing = _context.IssueTimings
                    .Include(x => x.employee)
                    .Where(x => x.issueDetailId == detailId)
                    .ToList();
            List<IssueTimingDto> response = _mapper.Map<List<IssueTimingDto>>(timing);
            return response;
        }

        public ReasignSupportDto ReasignSupport(ReasignSupportDto data)
        {
            IssueDetails? support = _context.IssueDetails
                .Include(x => x.timings)
                .Where(x => x.id == data.id)
                .FirstOrDefault();

            Empleado? employee = _context.Empleados.Where(x => x.CodigoEmpleado.Equals(data.employeeId)).FirstOrDefault();

            if(string.IsNullOrEmpty(data.title) || string.IsNullOrEmpty(data.title))
                throw new Exception("Los campos son obligatorios");

            if(employee is null)
                throw new Exception("No se encontró el empleado seleccionado, intente nuevamente");

            if(support is null)
                throw new Exception("No se encontró el pendiente");

            if (support.timings.Any(x => x.state == IssueStateEnum.PENDING))
                throw new Exception("Ya tiene un pendiente asignado aún no iniciado");

            if (support.timings.Any(x => x.state != IssueStateEnum.FINISHED))
                throw new Exception("Finalice el pendiente para poder reasignar");
            
            support.title = data.title;
            support.description = data.description;
            _context.IssueDetails.Update(support);
            IssueTimings timing = _mapper.Map<IssueTimings>(support);
            timing.createdAt = DateTime.Now;
            timing.employeeId = data.employeeId;
            _context.IssueTimings.Add(timing);
            _context.SaveChanges();
            return data;
        }
    }
}
