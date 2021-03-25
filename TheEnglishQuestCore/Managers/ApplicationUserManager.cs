using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestCore.Interfaces;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore.Managers
{
    public class ApplicationUserManager : DTOManager<ApplicationUser ,ApplicationUserDto>, IApplicationUserDto
    {
        protected readonly IApplicationUserRepository _ApplicationUserRepository;
        public ApplicationUserManager(IApplicationUserRepository _enc, DTOMapper<ApplicationUser, ApplicationUserDto> mapper) : base(mapper)
        {
            _ApplicationUserRepository = _enc;
        }

        public async Task<IdentityResult> AddUser(ApplicationUserDto user, string password, string typeofUser)
        {
            var entity = _DTOMapper.Map(user);
            return await _ApplicationUserRepository.AddUser(entity, password, typeofUser);
        }

        public async Task<bool> DeleteUser(string userid)
        {
            return await _ApplicationUserRepository.DeleteUser(userid);
        }

        public async Task<ApplicationUserDto> UpdateUser(ApplicationUserDto user)
        {
            var entity = _DTOMapper.Map(user);
            var updatedUser = await _ApplicationUserRepository.UpdateUser(entity);
            return _DTOMapper.Map(updatedUser);
        }
        public async Task<ApplicationUserDto> GetUser(string username)
        {
            var entity = await _ApplicationUserRepository.GetUser(username);
            var user = _DTOMapper.Map(entity);
            return user;
        }
        public async Task<ApplicationUserDto> GetLoggedUser(string userId)
        {
            var user = await _ApplicationUserRepository.GetLoggedUser(userId);
            var userDto = _DTOMapper.Map(user);
            return userDto;
        }

        public async Task<SignInResult> LogIn(string username, string password)
        {
            return await _ApplicationUserRepository.LogIn(username, password);
        }
        public async Task AssignLevel(double points, string userId)
        {
            await _ApplicationUserRepository.AssignLevel(points, userId);
        }

        public async Task LogOut()
        {
            await _ApplicationUserRepository.LogOut();
        }

    }
}
