using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;
using TheEnglishQuestDatabase.Repositories.Interfaces;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    class GrammarTaskRepository : BaseRepository<GrammarTask>, IGrammarTaskRepository
    {
        protected override DbSet<GrammarTask> DbSet => _db.GrammarTasks;
        public GrammarTaskRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<bool> Delete(GrammarTask entity)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }

        public async Task<bool> AddNew(GrammarTask entity)
        {
            await DbSet.AddAsync(entity);
            return await SaveChanges();
        }

        public async Task<IEnumerable<GrammarTask>> GetAllValues()
        {
            return await DbSet.Select(x => x).ToListAsync();
        }
    }
}
