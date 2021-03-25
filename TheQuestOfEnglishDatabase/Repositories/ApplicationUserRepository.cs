using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;
using TheQuestOfEnglishDatabase;


namespace TheEnglishQuestDatabase
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        protected override DbSet<ApplicationUser> DbSet => _db.ApplicationUser;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationUserRepository(ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager) : base(db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddUser(ApplicationUser user, string password, string typeofUser)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!await _roleManager.RoleExistsAsync(typeofUser))
            {
                await _roleManager.CreateAsync(new IdentityRole(typeofUser));
            }
            if (result.Succeeded)
            {
                var result2 = await _userManager.AddToRoleAsync(user, typeofUser);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return result2;
            }
            else
            {
                return result;
            }
        }

        public async Task<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            ApplicationUser userFromDb = await DbSet.Where(x => x.Id == user.Id).SingleOrDefaultAsync();
            userFromDb.FirstName = user.FirstName;
            userFromDb.LastName = user.LastName;
            userFromDb.Description = user.Description;
            userFromDb.Email = user.Email;
            await SaveChanges();
            return user;
        }
        public async Task<SignInResult> LogIn(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username,
            password, true, lockoutOnFailure: false);
            return result;
        }

        public async Task<ApplicationUser> GetUser(string username)
        {
            return await DbSet.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }
        public async Task<ApplicationUser> GetLoggedUser(string userId)
        {
            var user = await DbSet.Where(x => x.Id == userId).SingleOrDefaultAsync();
            return user;
        }

        public async Task AssignLevel(double points, string userId)
        {
            var user = await DbSet.Where(x => x.Id == userId).SingleOrDefaultAsync();
            if (points < 0.4)
            {
                user.Level = "B1";
            }
            if (points > 0.4 && points < 0.8)
            {
                user.Level = "B2";
            }
            if (points > 0.8)
            {
                user.Level = "C1";
            }
            await SaveChanges();
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<bool> DeleteUser(string id)
        {
            //Delete all!!!
            //var allEntities = DbSet.Select(x => x);
            //foreach (var item in allEntities)
            //{
            //    DbSet.Remove(item);
            //}
            //await SaveChanges();

            ///
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }
    }
}
