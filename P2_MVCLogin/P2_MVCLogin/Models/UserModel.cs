using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P2_MVCLogin.Models
{
    public class UserModel
    {

            [Required]
            [StringLength(150)]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [StringLength(20,MinimumLength=6)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            public string Apellido { get; set; }

            public string Nombre{get; set;}



    }
}