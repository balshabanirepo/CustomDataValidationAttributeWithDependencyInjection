using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataRepository.DataRepositoryEntities;
using DataRepository.GateWay;
using ServiceClassLibrary;
using DataModel;
using CustomDataValidationAttributeWithDependencyInjection.Models;
using DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsInterface;
using ServiceClassLibrary.Interface;

namespace CustomDataValidationAttributeWithDependencyInjection.Controllers
{
    public class PasswordComplexityRulesController : Controller
    {
        private readonly PasswordComplexityRulesServiceInterface _passwordComplexityRulesService;

        public PasswordComplexityRulesController(PasswordComplexityRulesServiceInterface passwordComplexityRulesService)
        {
            _passwordComplexityRulesService = passwordComplexityRulesService;
        }

        // GET: PasswordComplexityRules
      

        // GET: PasswordComplexityRules/Details/5
        public IActionResult Details()
        {
         
           
            var passwordComplexityRule = _passwordComplexityRulesService.GetPasswordComplexityRules();
            PasswordComplexityRuleViewModel complexityRuleViewModel= new PasswordComplexityRuleViewModel();
            complexityRuleViewModel.MinLength = passwordComplexityRule.MinLength;
            complexityRuleViewModel.MustContainLettersNumbers = passwordComplexityRule.MustContainLettersNumbers;
            complexityRuleViewModel.MustContainUpperLower = passwordComplexityRule.MustContainUpperLower;
            complexityRuleViewModel.MustContainSpecialCharacters = passwordComplexityRule.MustContainSpecialCharacters;
            complexityRuleViewModel.Id = passwordComplexityRule.Id;
            return View(complexityRuleViewModel);
        }

      
        // POST: PasswordComplexityRules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(PasswordComplexityRuleViewModel passwordComplexityRule)
        {
            if (ModelState.IsValid)
            {
                PasswordComplexityRuleDataModel complexityRuleDataModel = new PasswordComplexityRuleDataModel();
                complexityRuleDataModel.MinLength = passwordComplexityRule.MinLength;
                complexityRuleDataModel.MustContainLettersNumbers = passwordComplexityRule.MustContainLettersNumbers;
                complexityRuleDataModel.MustContainUpperLower = passwordComplexityRule.MustContainUpperLower;
                complexityRuleDataModel.MustContainSpecialCharacters = passwordComplexityRule.MustContainSpecialCharacters;
                complexityRuleDataModel.Id = passwordComplexityRule.Id;
                _passwordComplexityRulesService.SavePasswordComplexityRules(complexityRuleDataModel);
                ViewBag.SavedSuccessfully = "Saved Successfully";
            }
            return View("Details",passwordComplexityRule);
        }

        // GET: PasswordComplexityRules/Edit/5
       

        // POST: PasswordComplexityRules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       

    
    }
}
