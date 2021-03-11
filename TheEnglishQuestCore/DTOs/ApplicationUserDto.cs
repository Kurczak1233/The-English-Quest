using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace TheEnglishQuestDatabase.Entities
{
    public class ApplicationUserDto
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public string Login{ get; set; }
        public string Password{ get; set; }
        public string EmailAdress { get; set; }
        public int GrammarPercentagePoints { get; set; } = 0;
        public int ReadingPercentagePoints { get; set; } = 0;
        public int SpeakingPercentagePoints { get; set; } = 0;
        public int ListeningPercentagePoints { get; set; } = 0;
        public int WritingPercentagePoints { get; set; } = 0;
        public string Level { get; set; }
        public byte[] Picture { get; set; }

    }
}
