using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestDatabase
{
    public class GrammarQuiz
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        public string Name { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public IEnumerable<GrammarTask> GrammarTasks { get; set; }

    }
}
