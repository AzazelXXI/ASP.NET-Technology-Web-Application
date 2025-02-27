using Microsoft.AspNetCore.Mvc;
using TechnologyWebsite.Models;

namespace TechnologyWebsite.Controllers
{
    public class AuthenticateController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Username == "admin" && model.Password == "123")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model, string Day, string Month, string Year)
        {
            if (ModelState.IsValid)
            {
                // Convert Date of Birth
                if (int.TryParse(Day, out int d) && int.TryParse(Month, out int m) && int.TryParse(Year, out int y))
                {
                    model.DateOfBirth = new DateTime(y, m, d);
                }

                // TODO: Lưu model vào database
                TempData["SuccessMessage"] = "Registration successful!";
                return RedirectToAction("Login");
            }

            return View(model);
        }
    }
}
