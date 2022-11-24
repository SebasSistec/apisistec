using apisistec.Constants;
using apisistec.Context;
using apisistec.Dtos.Support;
using apisistec.Entities;
using apisistec.Interfaces;
using apisistec.Models.Common;
using AutoMapper;
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

            return created;
        }
    }
}
