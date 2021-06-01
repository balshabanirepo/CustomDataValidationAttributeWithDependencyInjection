using DataRepository.DataRepositoryEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataRepository.GateWay
{
   public class ContextGateway: IContextGateWay
    {
       
        public  RepositoryGateWay<PasswordComplexityRule> PasswordComplexityRules { get; set; }

        public  RepositoryGateWay<User> Users { get; set; }
     

        private static DbConext dbConext;
        public ContextGateway()
        {
            PasswordComplexityRules = new RepositoryGateWay<PasswordComplexityRule>();
            Users = new RepositoryGateWay<User>();


        }
       
      

        //private ContextGateway() { }

       
        private static IDbContextTransaction _transaction;



        public  void CreateDatabaseTransaction()
        {
            dbConext = DbConext.GetContextInstance();
            _transaction = dbConext.Database.BeginTransaction();
        }



        public  void Rollback()
        {
            _transaction.Rollback();
        }

        public   void Dispose()
        {
            _transaction.Dispose();
        }

        public  void Commit()
        {
            _transaction.Commit();

        }
    }
}
