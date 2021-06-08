
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;

#nullable disable


namespace CustomDataValidationAttributeWithDependencyInjection.Models
{
    public partial class UserViewModel
    {


        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [CustomClasses.CustomPassWordValidation]
        [Required]
        public string Password { get; set; }

        [Required]

        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}
