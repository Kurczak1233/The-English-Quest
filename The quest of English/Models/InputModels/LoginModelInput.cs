using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_quest_of_English.Models
{
    public class LoginModelInput
    {
        [Required]
        [Display(Name = "Login")]
        public string Login{ get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password{ get; set; }
    }
}
