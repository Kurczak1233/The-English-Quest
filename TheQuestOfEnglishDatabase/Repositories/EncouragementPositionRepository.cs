using Microsoft.EntityFrameworkCore;
using TheEnglishQuestDatabase.Entities;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class EncouragementPositionRepository : BaseRepository<EncouragementPosition>
    {
        protected override DbSet<EncouragementPosition> DbSet => _db.EncouragementPositions;
        public EncouragementPositionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
