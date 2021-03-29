using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnglishQuestDatabase
{
    public class GrammarTask : PlacementTestTask
    {
        public int GrammarQuizId{ get; set; }
        [ForeignKey("GrammarQuizId")]
        public virtual GrammarQuiz GrammarQuiz { get; set; }
    }
}
