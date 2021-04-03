using System.Collections.Generic;

namespace The_quest_of_English
{
    public class ReadingQuizViewModel : QuizViewModel
    {
        public IEnumerable<GrammarTasksViewModel> ReadingTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Reading";
    }
}
