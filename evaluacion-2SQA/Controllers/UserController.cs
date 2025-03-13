using Microsoft.AspNetCore.Mvc;
using UserApp.Services;
using UserApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private const int PageSize = 5;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            List<User> users = await _userService.GetUsersAsync(page, 10);

            if (users == null)
            {
                users = new List<User>(); // Nunca pasar null a la vista
            }

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = 10; // Puedes hacer un cálculo real aquí si lo necesitas

            return View(users);
        }
    }
}
