using Microsoft.EntityFrameworkCore;
using TheEnglishQuestDatabase.Entities;

namespace TheQuestOfEnglishDatabase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<EncouragementPosition> EncouragementPositions{ get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<SampleTestQA> SampleTestQA { get; set; }

    }
}
