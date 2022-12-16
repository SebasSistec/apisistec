﻿using apisistec.Constants;
using apisistec.Context;
using apisistec.Dtos;
using apisistec.Dtos.Support;
using apisistec.Entities;
using apisistec.Enums;
using apisistec.Extensions;
using apisistec.Interfaces;
using apisistec.Models.Common;
using apisistec.Models.Parameters;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly IWebHostEnvironment _env;


        public SupportService(
            DataContext context,
            IMapper mapper,
            IHttpContextAccessor httpContextAccesor,
            IWebHostEnvironment env,
            IOptions<AppSettings> appSettings,
            IMediaService mediaService)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccesor = httpContextAccesor;
            _appSettings = appSettings.Value;
            _mediaService = mediaService;
            _env = env;
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
                .Include(x => x.issueDetails)
                    .ThenInclude(x => x.files)
                .Include(x => x.issueDetails)
                    .ThenInclude(x => x.timings.OrderByDescending(x => x.createdAt))
                .Where(x => x.issueDetails.Any(x => x.employeeId == user.userId))
                .OrderBy(x => x.createdAt)
                .ToList();

            IEnumerable<SupportDto> supports = _mapper.Map<IEnumerable<SupportDto>>(issues);
            PaginationDto<SupportDto> paged = supports.GetPaged(qParams); 
            return paged;
        }

        public UpdateDetailTimingDto UpdateSupportDetail(UpdateDetailTimingDto detail)
        {
            CredentialsToken user = GetUserSupportCredentials();

            HttpRequest request = _httpContextAccesor.HttpContext.Request;
            string urlBaseImage = request.Host.Host;
            string a = $"{request.Scheme}://{urlBaseImage}/as";

            IssueTimings? timing = _context.IssueTimings.Where(x => x.id == detail.id).Include(x => x.detail).FirstOrDefault();
            if(timing is null)
                throw new Exception("No se encontró el pendiente");

            switch (detail.state)
            {
                case IssueStateEnum.STARTED:
                    IssueDetails? support = _context.IssueDetails
                        .Include(x => x.issue)
                        .Where(x => x.employeeId == user.userId && x.timings.Any(x => x.state == IssueStateEnum.STARTED))
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
    }
}
