using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore.Interfaces
{
    public interface IApplicationUserDto
    {
        Task<bool> AddNewUser(ApplicationUserDto user);
        Task<bool> DeleteUser(string id);
        Task<ApplicationUserDto> GetUser(string id);
    }
}
