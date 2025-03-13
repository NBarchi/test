using Microsoft.AspNetCore.Mvc;
using UserApp.Services;
using UserApp.Models;

namespace UserApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var users = await _userService.GetUsersAsync(page);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)users.Info.Results / 10); 

            return View(users.Results); 
        }

        public async Task<IActionResult> Details(string uuid)
        {
            var user = await _userService.GetUserAsync(uuid);
            return View(user);
        }
    }
}
