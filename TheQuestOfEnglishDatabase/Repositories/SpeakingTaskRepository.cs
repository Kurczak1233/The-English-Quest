using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class SpeakingTaskRepository : BaseRepository<SpeakingTask>, ISpeakingTaskRepository
    {
        protected override DbSet<SpeakingTask> DbSet => _db.SpeakingTasks;
        public SpeakingTaskRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<bool> Delete(SpeakingTask entity)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }

        public async Task<bool> AddNew(SpeakingTask entity)
        {
            await DbSet.AddAsync(entity);
            return await SaveChanges();
        }

        public async Task<SpeakingTask> FindTask(int id)
        {
            return await DbSet.Where(x => x.Id == id).SingleOrDefaultAsync();

        }
        public async Task<bool> ModifyTask(SpeakingTask task)
        {
            DbSet.Update(task);
            return await SaveChanges();
        }
        public async Task<IEnumerable<SpeakingTask>> GetAllValues()
        {
            return await DbSet.Select(x => x).ToListAsync();
        }
    }
}
