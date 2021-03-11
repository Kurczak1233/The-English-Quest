using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore.Interfaces
{
    public interface IApplicationUserDto
    {
        Task<bool> AddNewUser(IApplicationUserDto user);
        Task<bool> DeleteUser(IApplicationUserDto user);
        Task<IEnumerable<IApplicationUserDto>> GetUser(IApplicationUserDto user);
    }
}
