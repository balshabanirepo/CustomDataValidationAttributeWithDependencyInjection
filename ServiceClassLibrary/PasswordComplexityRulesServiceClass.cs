using DataModel;
using DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsInterface;
using ServiceClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceClassLibrary
{
    public class PasswordComplexityRulesServiceClass: PasswordComplexityRulesServiceInterface
    {
        private readonly PasswordComplexityRuleOperationInterface _PasswordComplexityRulesOperations;



        public PasswordComplexityRulesServiceClass(PasswordComplexityRuleOperationInterface PasswordComplexityRulesOperations)
        {
            // settingsModelMapper = new PasswordComplexityRulesModelMapper();

            _PasswordComplexityRulesOperations = PasswordComplexityRulesOperations;
        }
        public void SavePasswordComplexityRules(PasswordComplexityRuleDataModel PasswordComplexityRules)
        {

            _PasswordComplexityRulesOperations.SavePasswordComplexityRule(PasswordComplexityRules);
        }
        ////private void AddPasswordComplexityRules(PasswordComplexityRulesDataModel PasswordComplexityRules)
        ////{

        ////    _PasswordComplexityRulesOperations.AddPasswordComplexityRules(PasswordComplexityRules);

        ////}
        ////private void EditPasswordComplexityRules(PasswordComplexityRulesDataModel PasswordComplexityRules)
        ////{

        ////    _PasswordComplexityRulesOperations.Edit(PasswordComplexityRules);

        ////}
        public PasswordComplexityRuleDataModel GetPasswordComplexityRules()
        {
            //PasswordComplexityRulesModelMapper settingsModelMapper= new PasswordComplexityRulesModelMapper ();

            //List<PasswordComplexityRulesDataModel> PasswordComplexityRuleList = settingsModelMapper.list();
            //if (PasswordComplexityRuleList.Count > 0)
            //{
            //    return PasswordComplexityRuleList[0];


            //}
            List<PasswordComplexityRuleDataModel> PasswordComplexityRuleList = _PasswordComplexityRulesOperations.list();
            if (PasswordComplexityRuleList.Count > 0)
            {
                return PasswordComplexityRuleList[0];


            }
            return new PasswordComplexityRuleDataModel { Id = 0 };

        }
        public void Delete()
        {

            List<PasswordComplexityRuleDataModel> PasswordComplexityRuleList = _PasswordComplexityRulesOperations.list();
            if (PasswordComplexityRuleList.Count > 0)
            {
                _PasswordComplexityRulesOperations.Delete(PasswordComplexityRuleList[0].Id);


            }







        }
    }
}
