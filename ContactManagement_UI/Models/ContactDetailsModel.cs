using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement_UI.Models
{
    public class ContactDetailsModel : ContactManagement_Entities.Contact.ContactDetails
    {
        [Required(ErrorMessage = "Mobile is required")]
        [Display(Name = "Mobile")]
        [CheckRepetation]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,12}$", ErrorMessage = "Please enter valid mobile no, digit count should be in between 10 to 12")]
        public override string Mobile { get; set; }
    }

    public class CheckRepetation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string sErrorMessage = "Invalid mobile number";

            if (value == "11111111" || value == "111111111" || value == "1111111111" || value == "11111111111" || value == "111111111111")
            {
                return new ValidationResult(sErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}