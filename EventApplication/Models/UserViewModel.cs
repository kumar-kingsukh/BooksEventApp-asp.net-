using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventApplication.Models
{
    public class UserViewModel
    {
        public int? Id { get; set; }

        
        [Display(Name = "Name")]
        [StringLength(20, ErrorMessage =
            "Name should be less than or equal to 20 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email Id is required")]
        [Display(Name = "Email Id")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
                    ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^((?=.*?[A-Za-z0-9])(?=.*?[#?!@$%^&*-])).{5,}$", 
         ErrorMessage = "Password must be atleast 5 char long and contains a special character")]
        [Display(Name = "Password")]
        public string Password { get; set; }


        public string Role { get; set; }
    }
}