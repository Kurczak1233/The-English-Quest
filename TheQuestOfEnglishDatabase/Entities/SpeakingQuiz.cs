using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnglishQuestDatabase
{
    public class SpeakingQuiz : Quiz
    {
        [NotMapped]
        public IEnumerable<SpeakingTask> SpeakingTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Speaking";
    }
}
