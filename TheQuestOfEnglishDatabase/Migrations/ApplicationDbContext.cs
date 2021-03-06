using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace TheQuestOfEnglishDatabase
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<GrammarTask> GrammarTasks { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<PlacementTestTask> PlacementTestTasks{ get; set; }
        public DbSet<GrammarQuiz> Quizzes{ get; set; }
        public DbSet<ReadingTask> ReadingTasks { get; set; }
        public DbSet<ReadingQuiz> ReadingQuizes { get; set; }
        public DbSet<ListeningTask> ListegningTasks { get; set; }
        public DbSet<ListeningQuiz> ListegningQuizes { get; set; }
        public DbSet<WritingTask> WritingTasks { get; set; }
        public DbSet<WritingQuiz> WritingQuizzes { get; set; }
        public DbSet<SpeakingTask> SpeakingTasks { get; set; }
        public DbSet<SpeakingQuiz> SpeakingQuizzes { get; set; }

    }
}
