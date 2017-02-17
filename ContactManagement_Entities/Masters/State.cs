using ContactManagement_Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement_Entities.Masters
{
    public class State : CommonProperties
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "State Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country Name")]
        public int? CountryId { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }
    }
}
