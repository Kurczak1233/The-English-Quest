using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnglishQuestDatabase
{
    public class ReadingQuiz : Quiz
    {
        [NotMapped]
        public IEnumerable<ReadingTask> ReadingTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Reading";
    }
}
