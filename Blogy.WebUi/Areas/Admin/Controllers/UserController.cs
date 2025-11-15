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
    [Authorize(Roles = $"{Roles.Admin}")]

    public class UserController(UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager, IMapper _mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();

            var mappedUsers = _mapper.Map<List<ResultUserDto>>(users);

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                mappedUsers.Find(x => x.Id == user.Id).Roles = userRoles;
            }
            return View(mappedUsers);
        }

        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            ViewBag.fullName = user.FirstName + " " + user.LastName;
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            var assignRoleList = new List<AssignRoleDto>();

            foreach (var role in roles)
            {
                assignRoleList.Add(new AssignRoleDto
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    UserId = user.Id,
                    RoleExists = userRoles.Contains(role.Name)
                });
            }

            return View(assignRoleList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> model)
        {
            var userId = model.Select(x=>x.UserId).FirstOrDefault();
            var user = await _userManager.FindByIdAsync(userId.ToString());

            foreach(var role in model)
            {
                if(role.RoleExists)
                {
                    await _userManager.AddToRoleAsync(user,role.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user,role.RoleName);
                }
            }

            return RedirectToAction("Index"); 
        }

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
