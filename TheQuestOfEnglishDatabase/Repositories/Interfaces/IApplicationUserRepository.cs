using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetUser(string username);
        Task<bool> DeleteUser(string id);
        Task<IdentityResult> AddUser(ApplicationUser user, string password);
        Task<SignInResult> LogIn(string username, string password);
        Task<IdentityResult> AddAdminToUser(ApplicationUser user);
    }
}