using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class WritingTaskRepository : BaseRepository<WritingTask>, IWritingTaskRepository
    {
        protected override DbSet<WritingTask> DbSet => _db.WritingTasks;
        public WritingTaskRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<bool> Delete(WritingTask entity)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }

        public async Task<bool> AddNew(WritingTask entity)
        {
            await DbSet.AddAsync(entity);
            return await SaveChanges();
        }

        public async Task<WritingTask> FindTask(int id)
        {
            return await DbSet.Where(x => x.Id == id).SingleOrDefaultAsync();

        }
        public async Task<bool> ModifyTask(WritingTask task)
        {
            DbSet.Update(task);
            return await SaveChanges();
        }
        public async Task<IEnumerable<WritingTask>> GetAllValues()
        {
            return await DbSet.Select(x => x).ToListAsync();
        }
    }
}
