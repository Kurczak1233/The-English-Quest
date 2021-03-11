using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheEnglishQuestDatabase.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int FirstName { get; set; }
        [Required]
        public int LastName { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        [Range(0, 100)]
        public int GrammarPercentagePoints { get; set; } = 0;
        [Range(0, 100)]
        public int ReadingPercentagePoints { get; set; } = 0;
        [Range(0, 100)]
        public int SpeakingPercentagePoints { get; set; } = 0;
        [Range(0, 100)]
        public int ListeningPercentagePoints { get; set; } = 0;
        [Range(0, 100)]
        public int WritingPercentagePoints { get; set; } = 0;
        [Required]
        public string Level { get; set; }
        public byte[] Picture { get; set; }

    }
}
