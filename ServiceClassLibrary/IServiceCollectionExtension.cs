using DataRepository;
using DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsClasses;

using Microsoft.Extensions.DependencyInjection;
using ServiceClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddinterfacesonWhichServiceClassLibraryDepend(this IServiceCollection services)
        {
            services.AddSingleton<UserServiceInterface, UserServiceClass>();
            services.AddSingleton<IPasswordComplexityRulesServiceInterface, PasswordComplexityRulesServiceClass>();
            services.AddinterfacesonDataRepositoryDepends();
            return services;
        }
    }
}
