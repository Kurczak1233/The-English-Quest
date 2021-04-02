using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;
using TheEnglishQuestDatabase.Repositories.Interfaces;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase.Repositories
{
    public class SampleTestQARepository : BaseRepository<SampleTestQA>, ISampleTestQARepostitory
    {
        protected override DbSet<SampleTestQA> DbSet => _db.SampleTestQA;

        public SampleTestQARepository(ApplicationDbContext dbContext ): base(dbContext)
        {

        }

        public async Task<IEnumerable<SampleTestQA>> GetAllValues()
        {
            return await DbSet.Select(x => x).ToListAsync();
        }
        public async Task<bool> Delete(SampleTestQA entity)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }

        public async Task<bool> AddNew(SampleTestQA entity)
        {
            await DbSet.AddAsync(entity);
            return await SaveChanges();
        }
    }
}
