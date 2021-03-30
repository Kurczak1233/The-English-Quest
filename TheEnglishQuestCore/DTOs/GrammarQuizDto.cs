using System.Collections.Generic;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class GrammarQuizDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ApplicationUserDto User { get; set; }
        public IEnumerable<GrammarTaskDto> GrammarTasks { get; set; }
    }

}
