using API.Areas.Security.Models;
using BLL.Helpers;
using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Areas.Security.Controllers
{
    [Area("security")]
    public class PasswordsController : Controller
    {
        private readonly UserManager<User> _userManager;

        public PasswordsController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Change(string phoneNumber)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            if (user == null)
            {
                return View();
            }

            ChangePasswordViewModel viewModel = new()
            {
                PhoneNumber = phoneNumber
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Setup(string phoneNumber)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            if (user == null)
            {
                return View();
            }

            SetupPasswordViewModel viewModel = new()
            {
                PhoneNumber = phoneNumber
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Change(ChangePasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Password != viewModel.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Parollar mos kelmadi!");
                    return View(viewModel);
                }
                var user = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == viewModel.PhoneNumber);
                if (user == null)
                {
                    ModelState.AddModelError("Password", "Foydalanuvchi topilmadi!");
                    return View(viewModel);
                }

                var currentPasswordIdValid = await _userManager.CheckPasswordAsync(user, viewModel.CurrentPassword);
                if (!currentPasswordIdValid)
                {
                    ModelState.AddModelError("CurrentPassword", "Joriy parol xato!");
                    return View(viewModel);
                }

                await _userManager.ChangePasswordAsync(user, Constants.DEFAULT_PASSWORD, viewModel.Password);

                return RedirectToAction("success");
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Setup(SetupPasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Password != viewModel.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Parollar mos kelmadi!");
                    return View(viewModel);
                }
                var user = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == viewModel.PhoneNumber);
                if (user == null)
                {
                    ModelState.AddModelError("Password", "Foydalanuvchi topilmadi!");
                    return View(viewModel);
                }
                await _userManager.ChangePasswordAsync(user, Constants.DEFAULT_PASSWORD, viewModel.Password);

                return RedirectToAction("success");
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}
