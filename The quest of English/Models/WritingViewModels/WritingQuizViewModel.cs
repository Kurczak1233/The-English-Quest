using System.Collections.Generic;

namespace The_quest_of_English
{
    public class WritingQuizViewModel : QuizViewModel
    {
        public IEnumerable<WritingTaskViewModel> WritingTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Writing";
    }
}
