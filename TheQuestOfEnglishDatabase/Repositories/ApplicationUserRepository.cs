using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        protected override DbSet<ApplicationUser> DbSet => _db.ApplicationUser;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<ApplicationUser> GetUser(string id)
        {
            return await DbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
