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

        public virtual List<Entity> GetAll()
        {
            var list = new List<Entity>();
            var entities = DbSet;
            foreach (var entity in entities)
            {
                list.Add(entity);
            }
            return list;
        }

        public async Task<bool> SaveChanges()
        {
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> AddNew(Entity entity)
        {
            await DbSet.AddAsync(entity);
            return await SaveChanges();
        }
    }
}
