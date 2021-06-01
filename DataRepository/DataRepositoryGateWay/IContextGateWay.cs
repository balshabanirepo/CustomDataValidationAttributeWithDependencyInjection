using DataRepository.DataRepositoryEntities;
using DataRepository.GateWay;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.GateWay
{
    public interface IContextGateWay
    {
        public RepositoryGateWay<PasswordComplexityRule> PasswordComplexityRules { get; set; }

        public RepositoryGateWay<User> Users { get; set; }



        public void CreateDatabaseTransaction();



        public void Rollback();

        public void Dispose();
        public void Commit();
    }
}
