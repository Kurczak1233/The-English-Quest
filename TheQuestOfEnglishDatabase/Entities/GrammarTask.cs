using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnglishQuestDatabase
{
    public class GrammarTask : PlacementTestTask
    {
        [ForeignKey("GrammarQuiz")]
        public int GrammarQuizId{ get; set; }
        public virtual GrammarQuiz GrammarQuiz { get; set; }
    }
}
