using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnglishQuestDatabase
{
    public class ListeningQuiz : Quiz
    {
        [NotMapped]
        public IEnumerable<ListeningTask> ListeningTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Listening";
    }
}
