using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class WritingQuizMapper : DTOMapper3<WritingQuiz, WritingQuizDto,
        ApplicationUser, ApplicationUserDto,
        WritingTask, WritingTaskDto>
    {

    }
}
