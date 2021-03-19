using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore.Interfaces
{
    public interface IApplicationUserDto
    {
        Task<IdentityResult> AddUser(ApplicationUserDto user, string password, string typeofUser);
        Task<bool> DeleteUser(string id);
        Task<ApplicationUserDto> GetUser(string username);
        Task<SignInResult> LogIn(string username, string password);
    }
}
