using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Repositories;
using Application.Interfaces.Repository;
using Infrastructure.Data;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            // Add Identity
            services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //add user repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<ITimelineEventsRepository, TimelineEventsRepository>();
            return services;
        }
    }
}
