using Api_Consultorio.Extensiones;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Interfaces.Servicios;
using Consultorio.Business.Servicios;
using HealthChecks.UI.Client;
using Infraestructura.SQLServer.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.

////////////////
//Tag: Cargar configuracion de logger
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

//Tag: Construir Logger
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();
////////////////
builder.Services.AddMemoryCache();
var connection = builder.Configuration.GetConnectionString("SQLConnectionString");
builder.Services.ConfigureSQLDbContext(connection);

builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


//Inyectar Dependencia
builder.Services.AddScoped<IConsultaRepository, ConsultaSQLRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteSQLRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorSQLRepository>() ;
builder.Services.AddScoped<IUsuarioRepository, UsuarioSQLRepository>();

builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IDoctorServices, DoctorServices>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//los del JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

////////////////////////////////////////////////////////

builder.Services.AddHealthChecks()
    .AddCheck("App Running", () => HealthCheckResult.Healthy("la api funciona")
    )
    .AddSqlServer(
        "SQLConnectionString",
        healthQuery: "select 1",
        name: "SQL Server Status",
        failureStatus: HealthStatus.Unhealthy
    ).AddUrlGroup(
        new Uri("https://google.com"),
        name: "Security Server",
        failureStatus: HealthStatus.Degraded
    );


////////////////////////////////////////////////////////


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();//////////////////////////////////////////

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

////////////////////////////////
app.MapHealthChecks("/health-details", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
}
);

app.MapControllers();


app.Run();
