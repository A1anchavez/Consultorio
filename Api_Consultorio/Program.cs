using Api_Consultorio.Extensiones;
using Consultorio.Business.Interfaces;
using Infraestructura.SQLServer.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("SQLConnectionString");
builder.Services.ConfigureSQLDbContext(connection);

//Inyectar Dependencia
builder.Services.AddScoped<IConsultaRepository, ConsultaSQLRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteSQLRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorSQLRepository>() ;

//builder.Services.AddScoped<ILogger, Transversal.Loggers.Logger<ControllerBase>();

//IConsultaRepository repo = new ConsultaSQLRepository();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
