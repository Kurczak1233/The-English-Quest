using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase.Repositories
{
    public class PlacementTestTaskRepository : BaseRepository<PlacementTestTask>, IPlacementTestTaskRepository
    {
        protected override DbSet<PlacementTestTask> DbSet => _db.PlacementTestTasks;
        public PlacementTestTaskRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<PlacementTestTask>> GetAllValues()
        {
            return await DbSet.Select(x => x).ToListAsync();
        }

        public async Task<PlacementTestTask> GetEntityById(int id)
        {
            return await DbSet.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<bool> Delete(PlacementTestTask entity)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }

        public int GetCount()
        {
            return DbSet.Select(x => x).ToList().Count;
        }
        public async Task<bool> AddNew(PlacementTestTask entity)
        {
            await DbSet.AddAsync(entity);
            return await SaveChanges();
        }
    }
}
