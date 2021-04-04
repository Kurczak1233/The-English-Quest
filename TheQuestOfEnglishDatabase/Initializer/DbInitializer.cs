using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using The_quest_of_English.Utilities;
using TheEnglishQuestDatabase.Entities;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void Initialize()
        {

            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }

            }
            catch(Exception ex)
            {

            }

            if (_db.Roles.Any(r => r.Name == SD.AdminUser)) return;

            _roleManager.CreateAsync(new IdentityRole(SD.AdminUser)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.OrdinaryUser)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Michal",
                Email = "kurczak12333@gmail.com",
                FirstName = "Michal",
                LastName = "Kupczak",
                EmailConfirmed = false
            },
            "123456").GetAwaiter().GetResult();
            IdentityUser user = await _db.Users.FirstOrDefaultAsync(u => u.Email == "kurczak12333@gmail.com");
            await _userManager.AddToRoleAsync(user, SD.AdminUser);
        }
    }
}