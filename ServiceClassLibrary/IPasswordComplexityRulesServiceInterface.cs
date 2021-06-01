using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceClassLibrary
{
    public interface IPasswordComplexityRulesServiceInterface
    {
        public void Delete();

        public void SavePasswordComplexityRules(PasswordComplexityRuleDataModel PasswordComplexityRules);

        public PasswordComplexityRuleDataModel GetPasswordComplexityRules();

      
    }
}
