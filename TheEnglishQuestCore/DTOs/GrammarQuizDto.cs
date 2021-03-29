using System.Collections.Generic;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class GrammarQuizDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public IEnumerable<GrammarTask> GrammarTasks { get; set; }
    }

}
