﻿using Microsoft.AspNetCore.Identity;
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
        public async Task<IdentityResult> AddAdminRoleToUser(ApplicationUserDto user)
        {
            var userDb = _DTOMapper.Map(user);
            return await _ApplicationUserRepository.AddAdminToUser(userDb);
        }

        public async Task<IdentityResult> AddOrdinaryUserRoleToUser (ApplicationUserDto user)
        {
            var userDb = _DTOMapper.Map(user);
            return await _ApplicationUserRepository.AddOrdinaryRoleToUser(userDb);
        }
        public async Task<ApplicationUserDto> GetUser(string username)
        {
            var entity = await _ApplicationUserRepository.GetUser(username);
            var user = _DTOMapper.Map(entity);
            return user;
        }

        public async Task<SignInResult> LogIn(string username, string password)
        {
            return await _ApplicationUserRepository.LogIn(username, password);
        }
    }
}
