using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Blogy.WebUi.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUi.Controllers
{
    [Area(Roles.Admin)]
    public class UsersController(UserManager<AppUser> _userManager, IMapper _mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();

            var mappedUsers = _mapper.Map<List<ResultUserDto>>(users);

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach(var role in mappedUsers)
                {
                    role.Roles = userRoles;
                }
            }
            return View(mappedUsers);
        }
    }
}
