using DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsClasses;
using DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsInterface;
using DataRepository.GateWay;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddinterfacesonDataRepositoryDepends(this IServiceCollection services)
        {
            services.AddSingleton<IContextGateWay, ContextGateway>();
            services.AddSingleton<UserOperationInterface, UserOperationClass>();
            services.AddSingleton<PasswordComplexityRuleOperationInterface,PasswordComplexityRuleOperationsClass>();
            return services;
        }
    }
}
