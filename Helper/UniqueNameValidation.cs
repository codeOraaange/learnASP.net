using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using sportstore.Models;

namespace sportstore.Helper
{
    public class UniqueNameAttribute : ValidationAttribute
    {
       public string GetErrorMessage()=>
        "Nama Gabole Sama donggs..." ;

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            var _context =
                (Context)validationContext
                    .  GetService(typeof(Context));
            
            string name =(string)value;
            int check = _context.Category
                .Where(x=> 
                x.Name.ToLower() == name.ToLower())
                .Count();
            
            if(check>0)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}