using ContactManagement_Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement_Entities.Masters
{
    public class Country : CommonProperties
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Country code is required")]
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "Country name is required")]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
    }
}
