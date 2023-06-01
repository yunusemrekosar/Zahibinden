using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Zahibinden.Data.Entities;
using static Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal.LoginModel;

namespace Zahibinden.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Login sayfasını görüntüleyen Action metodu
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(InputModel model)
        {
            // Giriş işlemini gerçekleştiren Action metodu
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    // Giriş başarılı, kullanıcıyı oturum açtırın
                    await _signInManager.SignInAsync(user, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Hatalı giriş, hata mesajı gösterin
                    ModelState.AddModelError("", "Geçersiz kullanıcı adı veya parola");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            // Kayıt sayfasını görüntüleyen Action metodu
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal.RegisterModel.InputModel
 model)
        {
            // Kayıt işlemini gerçekleştiren Action metodu
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Kayıt başarılı, kullanıcıyı oturum açtırın
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Kayıt başarısız, hata mesajlarını gösterin
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }
    }
}
