using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class GrammarTaskRepository : BaseRepository<GrammarTask>, IGrammarTaskRepository
    {
        protected override DbSet<GrammarTask> DbSet => _db.GrammarTasks;
        public GrammarTaskRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<bool> Delete(GrammarTask entity)
        {
            //Delete some of them
            //var allEntities = await DbSet.Where(x => x.GrammarQuizId == 34).ToListAsync();
            //foreach (var item in allEntities)
            //{
            //    DbSet.Remove(item);
            //}
            //await SaveChanges();
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

        public async Task<GrammarTask> FindTask(int id)
        {
            return await DbSet.Where(x=>x.Id == id).SingleOrDefaultAsync();

        }
        public async Task<bool> ModifyTask(GrammarTask task)
        {
            DbSet.Update(task);
            return await SaveChanges();
        }
        public async Task<IEnumerable<GrammarTask>> GetAllValues()
        {
            return await DbSet.Select(x => x).ToListAsync();
        }

    }
}
