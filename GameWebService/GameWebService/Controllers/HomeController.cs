using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GameWebService.DAL.EntityFramework;
using System.Threading.Tasks;
using GameWebService.DAL.Models;
using GameWebService.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Security.Claims;

namespace GameWebService.Controllers
{
    public class HomeController : Controller
    {
        GameServiceContext db;

        public HomeController(GameServiceContext context)
        {
            db = context;
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Results()
        {
            return View(db.Results.ToList());
        }

        public IActionResult Cabinet()
        {
            //var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            return View();
        }

        public IActionResult Users()
        {
            return View(db.Users.ToList());
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User { Surname = model.Surname, Name = model.Name, MiddleName = model.MiddleName, Login = model.Login, Phone = model.Phone, Email = model.Email, Password = model.Password };
                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    db.Users.Add(user);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
    }
}
