using API.Areas.Security.Models;
using BLL.Helpers;
using BLL.Interfaces;
using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Areas.Security.Controllers
{
    [Area("security")]
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageService _messageService;

        public HomeController(UserManager<User> userManager,
            IMessageService messageService)
        {
            _userManager = userManager;
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(PhoneNumberViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == viewModel.PhoneNumber);
                if (user == null)
                {
                    ModelState.AddModelError(nameof(viewModel.PhoneNumber), "Bunday telefon raqam bizning ma'lumotlar omborimizdan topilmadi!");
                    return View();
                }
                var result = await _messageService.SendOTP(viewModel.PhoneNumber, HttpContext.Connection.RemoteIpAddress.ToString());
                if (!string.IsNullOrEmpty(result))
                {
                    return RedirectToAction("verify", "home", new { phoneNumber = result });
                }
                ModelState.AddModelError(nameof(viewModel.PhoneNumber), "Xatolik yuz berdi!");
                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Verify(string phoneNumber)
        {
            VerificationViewModel verification = new()
            {
                PhoneNumber = phoneNumber,
                Code = 0
            };

            return View(verification);
        }

        [HttpPost]
        public async Task<IActionResult> Verify(VerificationViewModel verification)
        {
            if (ModelState.IsValid)
            {
                var result = await _messageService.CheckOTP(verification.PhoneNumber, verification.Code);
                if (!result)
                {
                    ModelState.AddModelError("Code", "Noto'g'ri tasdiqlash kodi!");
                    return View(verification);
                }
                else
                {
                    var user = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == verification.PhoneNumber);
                    var hasDefaultPassword = await _userManager.CheckPasswordAsync(user??(new User()), Constants.DEFAULT_PASSWORD);
                    if (hasDefaultPassword)
                    {
                        return RedirectToAction("setup", "passwords", new { phoneNumber = result });
                    }

                    return RedirectToAction("change", "passwords", new { phoneNumber = result });
                }
            }
            verification = new VerificationViewModel()
            {
                PhoneNumber = verification.PhoneNumber,
                Code = 0
            };

            return View(verification);
        }

        public IActionResult PasswordSetup()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
