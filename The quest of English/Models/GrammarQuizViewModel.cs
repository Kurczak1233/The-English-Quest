using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace The_quest_of_English.Models
{
    public class GrammarQuizViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ApplicationUser User { get; set; }
        public IEnumerable<GrammarTask> GrammarTasks { get; set; }
    }
}
