using AutoMapper;
using Inpitsu.Data.DtoObjects;
using Inpitsu.Data.Models;
using Inpitsu.Filters;
using Inpitsu.Logger;
using Inpitsu.Servises.Interfaces;
using Inpitsu.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Inpitsu.Web.Manager
{
    public class UserManager
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILoggerManager _logger;
        public UserManager(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            IServiceManager service, IMapper mapper, IConfiguration configuration, ILoggerManager logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<UserListViewModel> GetUsers(PaginationFilter paginationFilter)
        {
            var userEntities = _userManager.Users.ToList();
            var count = _userManager.Users.Count();
            paginationFilter.Count = count;
            List<UserWithRolesDto> users = new List<UserWithRolesDto>();
            foreach (var user in userEntities)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                UserWithRolesDto userWithRolesDto = new UserWithRolesDto(
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.PhoneNumber,
                    userRoles,
                    user.LockoutEnabled,
                    user.Locked);
                users.Add(userWithRolesDto);
            }

            return new UserListViewModel()
            {
                Users = users,
                PaginationFilter = paginationFilter
            };
        }

        public UserViewModel GetUserModel(UserForRegistrationDto user)
        {

            return new UserViewModel()
            {
                User = user
            };
        }

        public async Task<User> GetUserById(string Id)
        {
            return await _userManager.FindByIdAsync(Id);
        }

        public async System.Threading.Tasks.Task UpdateUser(User user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async System.Threading.Tasks.Task LockUser(User user, bool isLock)
        {
            await _userManager.SetLockoutEnabledAsync(user, isLock);
            await _userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddYears(200));
            await _userManager.UpdateSecurityStampAsync(user);
            user.Locked = isLock;
            await _userManager.UpdateAsync(user);
        }

        public async Task<ChangeRoleViewModelDto> GetRoles(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();
            return new ChangeRoleViewModelDto
            {
                UserId = user.Id,
                UserEmail = user.Email,
                UserRoles = userRoles,
                AllRoles = allRoles
            };
        }

        public async System.Threading.Tasks.Task SetRoles(User user, List<string> roles)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var addedRoles = roles.Except(userRoles);
            var removedRoles = userRoles.Except(roles);
            await _userManager.AddToRolesAsync(user, addedRoles);
            await _userManager.RemoveFromRolesAsync(user, removedRoles);
        }

    }
}
