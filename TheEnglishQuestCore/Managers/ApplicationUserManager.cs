using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestCore.Interfaces;
using TheEnglishQuestDatabase;

namespace TheEnglishQuestCore.Managers
{
    public class ApplicationUserManager : DTOManager, IApplicationUserDto
    {
        public ApplicationUserManager(IEncouragementPositionRepository _enc, DTOMapper mapper) : base(_enc, mapper)
        {

        }

        public Task<bool> AddNewUser(IApplicationUserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(IApplicationUserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IApplicationUserDto>> GetUser(IApplicationUserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
