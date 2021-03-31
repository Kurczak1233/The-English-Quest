using System.Collections.Generic;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class GrammarQuizDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUserDto User { get; set; }
        public IEnumerable<GrammarTaskDto> GrammarTasks { get; set; }
    }

}
