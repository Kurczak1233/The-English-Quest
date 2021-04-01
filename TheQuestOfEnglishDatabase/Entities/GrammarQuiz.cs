using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnglishQuestDatabase
{
    public class GrammarQuiz : Quiz
    {
        [NotMapped]
        public IEnumerable<GrammarTask> GrammarTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Grammar";
    }
}
