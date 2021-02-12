using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Infrastruture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastruture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Add Application DbContext
            services.AddDbContext<CapgeminiDbContext>(options =>
                options.UseSqlite(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(CapgeminiDbContext).Assembly.FullName)));

            services.AddScoped<ICapgeminiDbContext>(provider => provider.GetService<CapgeminiDbContext>());

            return services;
        }
    }
}
