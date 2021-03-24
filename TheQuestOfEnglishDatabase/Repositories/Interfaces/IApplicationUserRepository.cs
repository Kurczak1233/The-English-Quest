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
        Task<IdentityResult> AddUser(ApplicationUser user, string password, string typeofUser);
        Task<SignInResult> LogIn(string username, string password);
        Task<ApplicationUser> GetLoggedUser(string userId);
        Task AssignLevel(double points, string userId);
    }
}