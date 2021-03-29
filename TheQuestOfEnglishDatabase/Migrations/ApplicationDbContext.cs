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
        public DbSet<EncouragementPosition> EncouragementPositions{ get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<SampleTestQA> SampleTestQA { get; set; }
        public DbSet<PlacementTestTask> PlacementTestTasks{ get; set; }
        public DbSet<GrammarQuiz> Quizzes{ get; set; }


    }
}
