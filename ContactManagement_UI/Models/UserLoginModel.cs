using System.ComponentModel.DataAnnotations;

namespace ContactManagement_UI.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "User name is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
    }
}