using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using DateMePlease.Extension;

namespace DateMePlease.Validators
{
    public class AgeRangeAttribute:ValidationAttribute
    {
        public AgeRangeAttribute(int min, int max)
        {
            _min = min;
            _max = max;
            ErrorMessage = "{0} must be between {1},{2}";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is DateTime))
            {
                throw new ValidationException("AgeRange Attribute is only valid for DateTime properties.");
            }
            //return base.IsValid(value, validationContext);
            var birthdate = (DateTime)value;
            if (birthdate.GetAge() < _min || birthdate.GetAge() > _max)
            {
               // return new ValidationResult("Age is outside the range");
                return new ValidationResult(this.FormatErrorMessage(validationContext.MemberName));
            }
            return ValidationResult.Success;

        }

        public int _min { get; set; }
        public int _max { get; set; }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessageString, name, _min, _max);
        }
    }

    
}