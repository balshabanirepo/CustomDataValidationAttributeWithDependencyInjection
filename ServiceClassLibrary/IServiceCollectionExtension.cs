using DataRepository;
using DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsClasses;
using DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsInterface;
using Microsoft.Extensions.DependencyInjection;
using ServiceClassLibrary;
using ServiceClassLibrary.Interface;
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
            services.AddSingleton<PasswordComplexityRulesServiceInterface, PasswordComplexityRulesServiceClass>();
            services.AddinterfacesonDataRepositoryDepends();
            return services;
        }
    }
}
