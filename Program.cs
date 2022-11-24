using apisistec.Context;
using apisistec.Helpers;
using apisistec.Interfaces;
using apisistec.Models;
using apisistec.Models.Common;
using apisistec.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "Files"
});

// Add services to the container.
string mySqlConnectionStr = builder.Configuration.GetConnectionString("ConnectionDB");
string MyCors = "_myAllowSpecificOrigins";

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(mySqlConnectionStr, ServerVersion.Parse("5.7.34-mysql"));
});
builder.Services.AddDbContext<DataContextProcedures>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("ConnectionDB"),
    ServerVersion.Parse("5.7.34-mysql"));
});

builder.Services.AddCors(p => p.AddPolicy(MyCors, builder => { builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); }));
builder.Services.AddAutoMapper(AutomapperProfiles.ProfilesConfig, AppDomain.CurrentDomain.GetAssemblies()); //Add automapper package
builder.Services.AddMemoryCache();

builder.Services.AddControllers(opcion =>
                                { opcion.Filters.Add(typeof(ExceptionFilter)); }).AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JWT Secret Key
IConfigurationSection appSettingsSection = builder.Configuration.GetSection("AppSettings:JwtSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
// JWT
AppSettings appSettings = appSettingsSection.Get<AppSettings>();
byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret!);
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwt =>
    {
        jwt.RequireHttpsMetadata = false;
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Inject Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IMailingService, MailingService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IRestorePasswordService, RestorePasswordService>();
builder.Services.AddScoped<IBillingService, BillingService>();
builder.Services.AddScoped<IAuthorizeBilling, AuthorizeBillingService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IContractedPlansService, ContractedPlansService>();
builder.Services.AddScoped<ILocalizationService, LocalizationService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ISupportService, SupportService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMediaService, MediaService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownProxies.Add(IPAddress.Parse("45.177.127.152"));
});

WebApplication app = builder.Build();
app.UseForwardedHeaders();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyCors);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
