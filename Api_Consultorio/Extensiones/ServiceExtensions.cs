using Infraestructura.SQLServer.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Api_Consultorio.Extensiones
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureSQLDbContext(this IServiceCollection services, string SqlConnection)
        {
            services.AddDbContext<SQLServerContext>(opt =>
            {
                opt.UseSqlServer(SqlConnection);
            });
        }
    }
}
