using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class ListeningTaskRepository : BaseRepository<ListeningTask>, IListeningTaskRepository
    {
        protected override DbSet<ListeningTask> DbSet => _db.ListegningTasks;
        public ListeningTaskRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<bool> Delete(ListeningTask entity)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }

        public async Task<bool> AddNew(ListeningTask entity)
        {
            await DbSet.AddAsync(entity);
            return await SaveChanges();
        }

        public async Task<ListeningTask> FindTask(int id)
        {
            return await DbSet.Where(x => x.Id == id).SingleOrDefaultAsync();

        }
        public async Task<bool> ModifyTask(ListeningTask task)
        {
            DbSet.Update(task);
            return await SaveChanges();
        }
        public async Task<IEnumerable<ListeningTask>> GetAllValues()
        {
            return await DbSet.Select(x => x).ToListAsync();
        }

    }
}
