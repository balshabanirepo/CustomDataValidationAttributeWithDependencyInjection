using ServiceClassLibrary;
using ServiceClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomDataValidationAttributeWithDependencyInjection.CustomClasses
{

    class CustomPassWordValidation:ValidationAttribute
    {
        protected PasswordComplexityRulesServiceInterface _passwordComplexityRuleService;
        
       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string PasswordValid;
            _passwordComplexityRuleService =(PasswordComplexityRulesServiceInterface) validationContext.GetService(typeof(PasswordComplexityRulesServiceInterface));
            var items = validationContext.Items;

            var z = _passwordComplexityRuleService;
            PasswordValid = CheckPasswordAgainstPasswordSettings(value.ToString());
          
            if (PasswordValid != "password valid")
            {
                    ErrorMessage = PasswordValid;
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;

          
        }
      string CheckPasswordAgainstPasswordSettings(string password)
        {
            Regex rxUpper = new Regex(@"[A-Z]");
            Regex rxLower = new Regex(@"[a-z]");



            var passwordcomplexityrulesetttings = _passwordComplexityRuleService.GetPasswordComplexityRules();
            if (passwordcomplexityrulesetttings == null)
            {
                return "password valid";
            }
            if (passwordcomplexityrulesetttings.MinLength > password.Length)
            {
                return "password is not of minimum length";

            }
            if (passwordcomplexityrulesetttings.MustContainLettersNumbers)
            {
                if (password.Any(a => !char.IsDigit(a) && !char.IsLetter(a)) && !passwordcomplexityrulesetttings.MustContainSpecialCharacters)

                {
                    return "password must contain letters and numbers";
                }


            }

            if (passwordcomplexityrulesetttings.MustContainSpecialCharacters)
            {

                if (!password.Any(a => !char.IsDigit(a) && !char.IsLetter(a)))

                {
                    return "password must contain special characters";
                }


            }
            if (passwordcomplexityrulesetttings.MustContainUpperLower)
            {

                if (!rxLower.Match(password).Success || !rxUpper.Match(password).Success)

                {
                    return "password must contain upper and lower case";
                }


            }

            return "password valid";

        }
    }
}
