using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public abstract class QuizDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; } 
        public ApplicationUserDto User { get; set; }
    }
}
