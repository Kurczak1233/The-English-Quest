using System.Collections.Generic;

namespace The_quest_of_English
{
    public class ListeningQuizViewModel : QuizViewModel
    {
        public IEnumerable<ListeningTasksViewModel> ListeningTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Listening";
    }
}
