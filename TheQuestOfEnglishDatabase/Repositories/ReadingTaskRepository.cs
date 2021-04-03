using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class ReadingTaskRepository : BaseRepository<ReadingTask>, IReadingTaskRepository
    {
        protected override DbSet<ReadingTask> DbSet => _db.ReadingTasks;
        public ReadingTaskRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<bool> Delete(ReadingTask entity)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }

        public async Task<bool> AddNew(ReadingTask entity)
        {
            await DbSet.AddAsync(entity);
            return await SaveChanges();
        }

        public async Task<ReadingTask> FindTask(int id)
        {
            return await DbSet.Where(x => x.Id == id).SingleOrDefaultAsync();

        }
        public async Task<bool> ModifyTask(ReadingTask task)
        {
            DbSet.Update(task);
            return await SaveChanges();
        }
        public async Task<IEnumerable<ReadingTask>> GetAllValues()
        {
            return await DbSet.Select(x => x).ToListAsync();
        }

    }
}
