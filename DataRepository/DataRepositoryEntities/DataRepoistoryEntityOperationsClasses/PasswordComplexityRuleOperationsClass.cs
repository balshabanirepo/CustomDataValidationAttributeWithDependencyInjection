using DataModel;
using DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsInterface;
using DataRepository.GateWay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsClasses
{
    class PasswordComplexityRuleOperationsClass : PasswordComplexityRuleOperationInterface
    {
        IContextGateWay _contextGateWay;
        public PasswordComplexityRuleOperationsClass(IContextGateWay contextGateWay)
        {
            _contextGateWay = contextGateWay;

        }
        public void Delete(int id)
        {
            _contextGateWay.PasswordComplexityRules.Delete(_contextGateWay.PasswordComplexityRules.GetById(g => g.Id == id));
        }

        public PasswordComplexityRuleDataModel GetById(int id)
        {
            PasswordComplexityRuleDataModel PasswordComplexityRuleDataModel;
            PasswordComplexityRule PasswordComplexityRule =
            PasswordComplexityRule = _contextGateWay.PasswordComplexityRules.GetById(g => g.Id == id);
            PasswordComplexityRuleDataModel = new PasswordComplexityRuleDataModel
            {
                Id = PasswordComplexityRule.Id,
                MinLength = PasswordComplexityRule.MinLength,
                MustContainLettersNumbers = PasswordComplexityRule.MustContainLettersNumbers,
                MustContainSpecialCharacters = PasswordComplexityRule.MustContainSpecialCharacters,
                MustContainUpperLower = PasswordComplexityRule.MustContainUpperLower
            };
            return PasswordComplexityRuleDataModel;
        }

        public List<PasswordComplexityRuleDataModel> list()
        {
            List<PasswordComplexityRule> PasswordComplexityRules = _contextGateWay.PasswordComplexityRules.List();
            return (from PasswordComplexityRule in PasswordComplexityRules
                    select
                new PasswordComplexityRuleDataModel
                {
                    Id = PasswordComplexityRule.Id,
                    MinLength = PasswordComplexityRule.MinLength,
                    MustContainLettersNumbers = PasswordComplexityRule.MustContainLettersNumbers,
                    MustContainSpecialCharacters = PasswordComplexityRule.MustContainSpecialCharacters,
                    MustContainUpperLower = PasswordComplexityRule.MustContainUpperLower
                }).ToList();

        }

        public void SavePasswordComplexityRule(PasswordComplexityRuleDataModel PasswordComplexityRuleDataModel)
        {

            if (PasswordComplexityRuleDataModel.Id > 0)
            {
                PasswordComplexityRule PasswordComplexityRule = _contextGateWay.PasswordComplexityRules.GetById(g => g.Id == PasswordComplexityRuleDataModel.Id),
                    PasswordComplexityRule1 = new PasswordComplexityRule
                    {
                        Id = PasswordComplexityRule.Id,
                        MinLength = PasswordComplexityRuleDataModel.MinLength,
                        MustContainLettersNumbers = PasswordComplexityRuleDataModel.MustContainLettersNumbers,
                        MustContainSpecialCharacters = PasswordComplexityRuleDataModel.MustContainSpecialCharacters,
                    };
                _contextGateWay.PasswordComplexityRules.Edit(PasswordComplexityRule, PasswordComplexityRule1);
            }
            else
            {
                _contextGateWay.PasswordComplexityRules.Add(new PasswordComplexityRule
                {
                    
                    MinLength = PasswordComplexityRuleDataModel.MinLength,
                    MustContainLettersNumbers = PasswordComplexityRuleDataModel.MustContainLettersNumbers,
                    MustContainSpecialCharacters = PasswordComplexityRuleDataModel.MustContainSpecialCharacters,
                });
            }
        }


    }
}
