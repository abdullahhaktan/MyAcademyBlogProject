using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Blogy.WebUi.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.Controllers
{
    [Area(Roles.Admin)] // Restrict access to Admin area only
    public class UsersController(UserManager<AppUser> _userManager, IMapper _mapper) : Controller
    {
        // Display list of all users with their roles
        public async Task<IActionResult> Index()
        {
            // Get all users from Identity database
            var users = _userManager.Users.ToList();

            // Map AppUser entities to ResultUserDto objects
            var mappedUsers = _mapper.Map<List<ResultUserDto>>(users);

            // Add role information to each user DTO
            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in mappedUsers)
                {
                    role.Roles = userRoles; // Assign roles to corresponding DTO
                }
            }
            return View(mappedUsers);
        }
    }
}