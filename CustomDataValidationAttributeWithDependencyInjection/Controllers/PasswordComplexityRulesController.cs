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

namespace CustomDataValidationAttributeWithDependencyInjection.Controllers
{
    public class PasswordComplexityRulesController : Controller
    {
        private readonly IPasswordComplexityRulesServiceInterface _passwordComplexityRulesService;

        public PasswordComplexityRulesController(IPasswordComplexityRulesServiceInterface passwordComplexityRulesService)
        {
            _passwordComplexityRulesService = passwordComplexityRulesService;
        }

        // GET: PasswordComplexityRules
      

        // GET: PasswordComplexityRules/Details/5
        public IActionResult Details()
        {
         
           
            var passwordComplexityRule = _passwordComplexityRulesService.GetPasswordComplexityRules();
           

            return View(passwordComplexityRule);
        }

      
        // POST: PasswordComplexityRules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(PasswordComplexityRuleDataModel passwordComplexityRule)
        {
            if (ModelState.IsValid)
            {
                
                _passwordComplexityRulesService.SavePasswordComplexityRules(passwordComplexityRule);
                return RedirectToAction(nameof(Index));
            }
            return View(passwordComplexityRule);
        }

        // GET: PasswordComplexityRules/Edit/5
       

        // POST: PasswordComplexityRules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       

    
    }
}
