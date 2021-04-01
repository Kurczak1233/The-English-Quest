using System.Collections.Generic;

namespace The_quest_of_English
{
    public class GrammarQuizViewModel : QuizViewModel
    {
        public IEnumerable<GrammarTasksViewModel> GrammarTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Grammar";
    }
}
