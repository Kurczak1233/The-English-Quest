using System.Collections.Generic;
using TheEnglishQuest;

namespace The_quest_of_English
{
    public class GrammarQuizViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUserViewModel User { get; set; }
        public IEnumerable<GrammarTasksViewModel> GrammarTasks { get; set; }
    }
}
