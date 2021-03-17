using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetUser(string id);
        Task<bool> DeleteUser(string id);
        Task<IdentityResult> AddUser(ApplicationUser user, string inputPassword);
        Task LogIn(ApplicationUser user);
    }
}