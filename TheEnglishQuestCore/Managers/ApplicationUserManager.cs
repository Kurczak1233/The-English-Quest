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

        public async Task<IdentityResult> AddUser(ApplicationUserDto user, string indexPassword)
        {
            var entity = _DTOMapper.Map(user);
            return await _ApplicationUserRepository.AddUser(entity, indexPassword);
        }

        public async Task<bool> DeleteUser(string userid)
        {
            return await _ApplicationUserRepository.DeleteUser(userid);
        }

        public async Task<ApplicationUserDto> GetUser(string userid)
        {
            var entity = await _ApplicationUserRepository.GetUser(userid);
            var user = _DTOMapper.Map(entity);
            return user;
        }

        public async Task LogIn(ApplicationUserDto user)
        {
            var userDto = _DTOMapper.Map(user);
            await _ApplicationUserRepository.LogIn(userDto);
        }
    }
}
