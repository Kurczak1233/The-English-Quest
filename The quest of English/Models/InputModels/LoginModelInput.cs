using System.ComponentModel.DataAnnotations;

namespace The_quest_of_English
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
