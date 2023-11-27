using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Inpitsu.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Inpitsu.Data.DtoObjects;
using System.Collections.Generic;
namespace Inpitsu.Web.Areas.Admins.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UsersController : Controller
    {
        UserManager<User> _userManager;
        RoleManager<IdentityRole> _roleManager;
        public UsersController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            List<UserWithRolesDto> roles = new List<UserWithRolesDto>();
            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                UserWithRolesDto userWithRolesDto = new UserWithRolesDto(user.Id, user.UserName, user.Email, user.PhoneNumber, userRoles, user.LockoutEnabled, user.Locked);
                roles.Add(userWithRolesDto);
            }

            return View(roles.OrderBy(c => c.UserName));
        }
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            User model = new User { Id = user.Id, Email = user.Email, UserName = user.UserName, PhoneNumber = user.PhoneNumber };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.UserName;
                    user.PhoneNumber = model.PhoneNumber;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }
        public RedirectToActionResult Cansel()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string Id, bool Locked)
        {
            var user = await _userManager.FindByIdAsync(Id);

            user.LockoutEnd = DateTime.Now.AddYears(200);
            user.LockoutEnabled = Locked;
            user.Locked = Locked;
            await _userManager.UpdateAsync(user);
            await _userManager.UpdateSecurityStampAsync(user);
            return RedirectToAction("Index");
        }

        public IActionResult Create() => View("CreateUser");
        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email, EmailConfirmed = true, PhoneNumber = model.PhoneNumber, Locked = false };
                var result = await _userManager.CreateAsync(user, model.PasswordHash);
                user.LockoutEnabled = false;
                user.LockoutEnd = null;
                await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View("CreateUser", model);
        }

        public async Task<IActionResult> EditRole(string Id)
        {
            User user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModelDto model = new ChangeRoleViewModelDto
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(string userId, List<string> roles)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);
                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);
                return RedirectToAction("Index");
            }

            return NotFound();
        }

    }
}
