using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Raw_Vidly_App.Models
{
    public class Min18yearsRequired : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customer customer = (Customer)validationContext.ObjectInstance;

            if (customer.BirthDate==null)
            {
                return new ValidationResult("Bithdate is required");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Year;

            return (age>=18) ? ValidationResult.Success :
            new ValidationResult("Minimmum 18 years only");

        }
    }
}