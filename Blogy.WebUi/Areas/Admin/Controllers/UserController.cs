using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Blogy.WebUi.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogy.WebUi.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = $"{Roles.Admin}")] // Admin area with Admin role requirement

    public class UserController(UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager, IMapper _mapper) : Controller
    {
        // Display list of all users with their assigned roles
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();

            // Map AppUser entities to ResultUserDto objects
            var mappedUsers = _mapper.Map<List<ResultUserDto>>(users);

            // Populate roles for each user
            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                // Find corresponding DTO and assign roles
                mappedUsers.Find(x => x.Id == user.Id).Roles = userRoles;
            }
            return View(mappedUsers);
        }

        // Display role assignment form for specific user
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            ViewBag.fullName = user.FirstName + " " + user.LastName; // Display user's full name

            // Get all available roles
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            var assignRoleList = new List<AssignRoleDto>();

            // Create list of roles with checkbox status
            foreach (var role in roles)
            {
                assignRoleList.Add(new AssignRoleDto
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    UserId = user.Id,
                    RoleExists = userRoles.Contains(role.Name) // Check if user already has this role
                });
            }

            return View(assignRoleList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> model)
        {
            var userId = model.Select(x => x.UserId).FirstOrDefault();
            var user = await _userManager.FindByIdAsync(userId.ToString());

            // Process each role checkbox
            foreach (var role in model)
            {
                if (role.RoleExists)
                {
                    // Add user to role if checkbox is checked
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
                else
                {
                    // Remove user from role if checkbox is unchecked
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
            }

            return RedirectToAction("Index");
        }

        // Note: Commented out code below appears to be an incomplete version of the above method
        //public async Task<IActionResult> AssignRole(List<AssignRoleDto> model)
        //{
        //    var userId = model.Select(x => x.UserId).FirstOrDefault();
        //    var user = await _userManager.FindByIdAsync(userId.ToString());

        //    foreach(var role in model)
        //    {
        //        if(role.RoleExists)
        //        {
        //            await _
        //        }
        //    }
        //}
    }
}