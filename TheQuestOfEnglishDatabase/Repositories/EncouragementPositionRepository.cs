using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class EncouragementPositionRepository : BaseRepository<EncouragementPosition>, IEncouragementPositionRepository
    {
        protected override DbSet<EncouragementPosition> DbSet => _db.EncouragementPositions;
        public EncouragementPositionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<EncouragementPosition>> GetAllPositions()
        {
            return await DbSet.Select(x => x).ToListAsync();
        }
        public async Task<bool> Delete(EncouragementPosition entity)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }
    }
}
