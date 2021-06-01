using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsInterface
{
   public interface PasswordComplexityRuleOperationInterface
    {
        public void SavePasswordComplexityRule(PasswordComplexityRuleDataModel systemSettings);




        public void Delete(int id);


        PasswordComplexityRuleDataModel GetById(int id);

        public List<PasswordComplexityRuleDataModel> list();
    }
}
