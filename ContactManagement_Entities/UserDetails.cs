﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement_Entities
{

    public class UserDetails : Common.CommonProperties
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User Group is required")]
        [Display(Name = "User Group")]
        public int UserGroupId { get; set; }

        [Required(ErrorMessage = "User code is required")]
        [Display(Name = "User Name")]
        public string User_Code { get; set; }

        //[Required(ErrorMessage = "User name is required")]
        //[Display(Name = "User Name")]
        public string User_Name { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        //[Display(Name = "Password")]
        //[DataType(DataType.Password)]
        public string User_Password { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [Display(Name = "Email Address")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format")]
        public string User_EmailId { get; set; }
    }
}
