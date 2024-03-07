using Ardil.Application.Repositories.EntryRepository;
using Ardil.Persistence.Repositories.EntryRepository;
using Ardil.Domain.Entities.Identity;
using Ardil.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Ardil.Application.Helper;
using Ardil.Application.Abstractions;
using Ardil.Persistence.Concretes;
using Ardil.Application.Repositories.TopicRepository;
using Ardil.Persistence.Repositories.TopicRepository;
using Ardil.Persistence.Concretes.Identity;
using Ardil.Application.Abstractions.Identity;
using Ardil.Application.Abstractions.Jwt;
using Ardil.Persistence.Concretes.Jwt;

namespace Ardil.Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ArdilDbContext>();
            services.AddScoped<ITokenHandler, TokenHandler>();

            services.AddScoped<IEntryReadRepository, EntryReadRepository>();
            services.AddScoped<IEntryService, EntryService>();

            services.AddScoped<ITopicReadRepository, TopicReadRepository>();
            services.AddScoped<ITopicService, TopicService>();

            services.AddScoped<IAuthService, AuthService>();

        }

        public static void InjectAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }


    }
}
