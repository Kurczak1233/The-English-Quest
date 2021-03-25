using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace TheEnglishQuestDatabase.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
        public string Level { get; set; }
        public byte[] Picture { get; set; }

    }
}
