using Api_Consultorio.Extensiones;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Interfaces.Servicios;
using Consultorio.Business.Servicios;
using Infraestructura.SQLServer.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
//builder.Services.AddScoped<IConsultaServices, ConsultaServices>();
builder.Services.AddScoped<IDoctorServices, DoctorServices>();


//builder.Services.AddScoped<ILogger, Transversal.Loggers.Logger<ControllerBase>();

//IConsultaRepository repo = new ConsultaSQLRepository();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
