using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TokenBasedAuthentication.API.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }




        [Required, DataType(DataType.Password)]
        public string Password { get; set; }





        [Required, Display(Name = "Confirm Password"), DataType(DataType.Password), Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}