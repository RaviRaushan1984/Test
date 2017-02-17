using ContactManagement_Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement_Entities.Masters
{
    public class City : CommonProperties
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "City Name")]
        public string Name { get; set; }

        public State State { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State Name")]
        public int? StateId { get; set; }

        public string StateName { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country Name")]
        public int CountryId { get; set; }

        public string CountryName { get; set; }
    }
}
