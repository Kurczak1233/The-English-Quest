using TheEnglishQuest;

namespace The_quest_of_English
{
    public abstract class QuizViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public ApplicationUserViewModel User { get; set; }
    }
}
