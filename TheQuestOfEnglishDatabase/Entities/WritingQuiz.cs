using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnglishQuestDatabase
{
    public class WritingQuiz : Quiz
    {
        [NotMapped]
        public IEnumerable<WritingTask> WritingTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Writing";
    }
}
