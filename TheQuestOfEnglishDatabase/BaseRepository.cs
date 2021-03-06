using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheQuestOfEnglishDatabase
{
    public abstract class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        protected ApplicationDbContext _db;
        protected abstract DbSet<Entity> DbSet { get; }
        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();
            //var list2 = await _db.Settings.ToListAsync(); Simplier?
            var entities = DbSet; //Wszystkie settingi się tutaj znajdą.
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
        public async Task<bool> Delete(Entity entity)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }
    }
}
