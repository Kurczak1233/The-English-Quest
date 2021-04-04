using System.Collections.Generic;

namespace The_quest_of_English
{
    public class SpeakingQuizViewModel : QuizViewModel
    {
        public IEnumerable<SpeakingTaskViewModel> SpeakingTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Speaking";
    }
}
