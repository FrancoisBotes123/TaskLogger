using Microsoft.EntityFrameworkCore;
using TaskLoggerApi.Data;
using TaskLoggerApi.Interfaces;
using TaskLoggerApi.Services;

namespace TaskLoggerApi.Extentions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,IConfiguration config)
        {
            // Configure DbContext with the connection string
            services.AddDbContext<TaskLoggerDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("connString")));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();

            return services;

        }
    }
}
