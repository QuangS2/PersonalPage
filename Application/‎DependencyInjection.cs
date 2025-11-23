using Application.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Services;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add application services here
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITechnologyService, TechnologyService>();
            services.AddScoped<ITimelineEventsService, TimelineEventsService>();
            return services;
        }
    }
}
