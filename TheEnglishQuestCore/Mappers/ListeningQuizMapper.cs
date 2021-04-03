using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class ListeningQuizMapper : DTOMapper3<ListeningQuiz, ListeningQuizDto,
        ApplicationUser, ApplicationUserDto,
        ListeningTask, ListeningTaskDto>
    {
    }
}
