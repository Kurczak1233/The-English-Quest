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
        Task<IdentityResult> AddUser(ApplicationUserDto user, string indexPassword);
        Task<bool> DeleteUser(string id);
        Task<ApplicationUserDto> GetUser(string id);
        Task LogIn(ApplicationUserDto user);
    }
}
