using System.Collections.Generic;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class GrammarQuizDto : QuizDto
    {
        public IEnumerable<GrammarTaskDto> GrammarTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Grammar";
    }

}
