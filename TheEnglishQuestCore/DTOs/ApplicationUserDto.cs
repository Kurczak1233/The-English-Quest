using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using TheEnglishQuestCore;

namespace TheEnglishQuestDatabase.Entities
{
    public class ApplicationUserDto : IdentityUser
    {
        public string CroppedPicture { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public int GrammarPercentagePoints { get; set; } = 0;
        public int ReadingPercentagePoints { get; set; } = 0;
        public int SpeakingPercentagePoints { get; set; } = 0;
        public int ListeningPercentagePoints { get; set; } = 0;
        public int WritingPercentagePoints { get; set; } = 0;
        public string Level { get; set; }
        public byte[] Picture { get; set; }
        public IEnumerable<GrammarQuizDto> GrammarQuizzes { get; set; }
    }
}
