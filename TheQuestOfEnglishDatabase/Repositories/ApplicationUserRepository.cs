using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_quest_of_English.Utilities;
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

        public async Task<IdentityResult> AddUser(ApplicationUser user, string password)
        {

            return await _userManager.CreateAsync(user, password);
        }

        public async Task<SignInResult> LogIn(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username,
            password, true, lockoutOnFailure: false);
            return result;
        }

        public async Task<IdentityResult> AddAdminToUser(ApplicationUser user)
        {
            if (!await _roleManager.RoleExistsAsync(SD.AdminUser))
            {
                await _roleManager.CreateAsync(new IdentityRole(SD.AdminUser));
            }
            return await _userManager.AddToRoleAsync(user, SD.AdminUser);

        }
        public async Task<ApplicationUser> GetUser(string username)
        {
            return await DbSet.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }
        public async Task<bool> DeleteUser(string id)
        {

            var allEntities = DbSet.Select(x => x);
            foreach (var item in allEntities)
            {
                DbSet.Remove(item);
            }
            await SaveChanges();
            //var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == id);
            //if (foundEntity != null)
            //{
            //    DbSet.Remove(foundEntity);
            //    return await SaveChanges();
            //}
            return false;
        }
    }
}
