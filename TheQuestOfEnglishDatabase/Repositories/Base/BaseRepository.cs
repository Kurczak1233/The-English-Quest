using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheQuestOfEnglishDatabase
{
    public abstract class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class
    {
        protected ApplicationDbContext _db;
        protected abstract DbSet<Entity> DbSet { get; }
        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> SaveChanges()
        {
            return await _db.SaveChangesAsync() > 0;
        }

    }
}
