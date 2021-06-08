using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;

#nullable disable


namespace CustomDataValidationAttributeWithDependencyInjection.Models
{
    public partial class PasswordComplexityRuleViewModel
    {
        public int Id { get; set; }
        public bool MustContainLettersNumbers { get; set; }
        public bool MustContainSpecialCharacters { get; set; }
        public bool MustContainUpperLower { get; set; }
        [Required]
        [Range(1,short.MaxValue)]
        public short MinLength { get; set; }
       
    }
}
