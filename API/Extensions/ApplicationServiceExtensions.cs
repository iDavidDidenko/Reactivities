using Application.Activities;
using Application.Core;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extenstions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // we add here a new DB service
            // DataContext the class we use to DBcontext
            services.AddDbContext<DataContext>(ops =>
            {
                // define the connection in - "app settings.development.json"
                ops.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors(ops =>
            {
                ops.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });

            // Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MyList.Handler).Assembly));
            // AutoMapper
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}