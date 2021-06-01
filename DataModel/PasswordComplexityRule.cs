using System;
using System.Collections.Generic;
using System.Net;

#nullable disable


namespace DataModel
{
    public partial class PasswordComplexityRuleDataModel
    {
        public int Id { get; set; }
        public bool MustContainLettersNumbers { get; set; }
        public bool MustContainSpecialCharacters { get; set; }
        public bool MustContainUpperLower { get; set; }
        public short MinLength { get; set; }
       
    }
}
