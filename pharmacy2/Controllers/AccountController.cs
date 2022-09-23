using BE;
using IdentitySample.Security.PhoneTotp;
using IdentitySample.Security.PhoneTotp.Providers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using pharmacy2.Models;
using pharmacy2.Repositories;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Kavenegar;
using Kavenegar.Exceptions;

namespace pharmacy2.Controllers
{
    
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private readonly IMessageSender _messageSender;
        private readonly IPhoneTotpProvider _phoneTotpProvider;
        private readonly PhoneTotpOptions _phoneTotpOptions;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMessageSender messageSender, IPhoneTotpProvider phoneTotpProvider,
            //PhoneTotpOptions phoneTotpOptions,
            IOptions<PhoneTotpOptions> phoneTotpOptions)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _messageSender = messageSender;
            _phoneTotpProvider = phoneTotpProvider;
            _phoneTotpOptions = phoneTotpOptions?.Value ?? new PhoneTotpOptions();
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register_Model model)
        {
            
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "home");
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    //EmailConfirmed = true,نیاز به تایید ایمیل
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var emailConfirmationToken =
                        await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var emailMessage =
                        Url.Action("ConfirmEmail", "Account",
                            new { username = user.UserName, token = emailConfirmationToken },
                            Request.Scheme);
                    await _messageSender.SendEmailAsync(model.Email, "Email confirmation", emailMessage);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LoginAsync(string returnUrl)
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "home");
            var model = new Login_Model()
            {
                ReturnURL = returnUrl,
                ExternalLogins =(await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            ViewData["returnUrl"] = returnUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login_Model model, string returnUrl = null)
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "home");
            model.ReturnURL = returnUrl;
            model.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ViewData["returnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, true, true);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return RedirectToAction("Index", "home");
                }

                if (result.IsLockedOut)
                {
                    ViewData["ErrorMessage"] = "اکانت شما به علت 5 بار ورود ناموفق قفل شده است";
                    return View(model);
                }
                ModelState.AddModelError("", "رمز عبور یا نام کاربری اشتباه است");
            }
            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return Json(true);
            return Json("ایمیل وارد شده تکراری است");
        }

        public async Task<IActionResult> IsUserNameInUse(string UserName)
        {
            var newuser = await userManager.FindByEmailAsync(UserName);
            if (newuser == null) return Json(true);
            return Json("نام کاربری تکرار است");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userName, string token)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(token))
                return NotFound();
            var user = await userManager.FindByNameAsync(userName);
            if (user == null) return NotFound();
            var result = await userManager.ConfirmEmailAsync(user, token);

            return Content(result.Succeeded ? "Email Confirmed" : "Email Not Confirmed");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPassword_Model model)
        {
            if (ModelState.IsValid)
            {
                var loginViewModel = new Login_Model()
                {
                    ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
                };

                ViewData["ErrorMessage"] = "اگر ایمیل وارد معتبر باشد، لینک فراموشی رمزعبور به ایمیل شما ارسال شد";

                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null) return View("Login", loginViewModel);

                var resetPasswordToken = await userManager.GeneratePasswordResetTokenAsync(user);
                var resetPasswordUrl = Url.Action("ResetPassword", "Account",
                    new { email = user.Email, token = resetPasswordToken }, Request.Scheme);

                await _messageSender.SendEmailAsync(user.Email, "reset password link", resetPasswordUrl);

                //return View("Login", loginViewModel);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
                return RedirectToAction("Index", "Home");

            var model = new ResetPassword_Model()
            {
                Email = email,
                Token = token
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPassword_Model model)
        {
            if (ModelState.IsValid)
            {
                var loginViewModel = new Login_Model()
                {
                    ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
                };

                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null) return RedirectToAction("Login", loginViewModel);
                var result = await userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    ViewData["ErrorMessage"] = "رمزعبور شما با موفقیت تغییر یافت";
                    return View("Login", loginViewModel);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SendTotpCode()
        {
            if (signInManager.IsSignedIn(User)) return RedirectToAction("Index", "Home");
            if (TempData.ContainsKey("PTC"))
            {
                var totpTempDataModel = JsonSerializer.Deserialize<PhoneTotpTempDataModel>(TempData["PTC"].ToString()!);
                if (totpTempDataModel.ExpirationTime >= DateTime.Now)
                {
                    var differenceInSeconds = (int)(totpTempDataModel.ExpirationTime - DateTime.Now).TotalSeconds;
                    ModelState.AddModelError("", $"برای ارسال دوباره کد، لطفا {differenceInSeconds} ثانیه صبر کنید.");
                    TempData.Keep("PTC");
                    return View();
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendTotpCode(SendTotpCodeViewModel model)
        {
            if (signInManager.IsSignedIn(User)) return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                if (TempData.ContainsKey("PTC"))
                {
                    var totpTempDataModel = JsonSerializer.Deserialize<PhoneTotpTempDataModel>(TempData["PTC"].ToString()!);
                    if (totpTempDataModel.ExpirationTime >= DateTime.Now)
                    {
                        var differenceInSeconds = (int)(totpTempDataModel.ExpirationTime - DateTime.Now).TotalSeconds;
                        ModelState.AddModelError("", $"برای ارسال دوباره کد، لطفا {differenceInSeconds} ثانیه صبر کنید.");
                        TempData.Keep("PTC");
                        return View();
                    }
                }

                var secretKey = Guid.NewGuid().ToString();

                var userExists = await userManager.Users
                    .AnyAsync(user => user.PhoneNumber == model.PhoneNumber);
                if (userExists)
                {
                    var totpCode = _phoneTotpProvider.GenerateTotp(secretKey);
                    //TODO send totpCode to user.
                    Uri apiBaseAddress = new Uri("https://console.melipayamak.com");
                    using (HttpClient client = new HttpClient() { BaseAddress = apiBaseAddress })
                    {
                        // You may need to Install-Package Microsoft.AspNet.WebApi.Client
                        var result = client.PostAsJsonAsync("api/send/simple/60bacae4f2f04842814a0611d8882975",
                            new { from = "50004001623816", to = model.PhoneNumber, text = totpCode }).Result;
                        var response = result.Content.ReadAsStringAsync().Result;
                    }
                }

                TempData["PTC"] = JsonSerializer.Serialize(new PhoneTotpTempDataModel()
                {
                    SecretKey = secretKey,
                    PhoneNumber = model.PhoneNumber,
                    ExpirationTime = DateTime.Now.AddSeconds(_phoneTotpOptions.StepInSeconds)
                });

               return RedirectToAction("VerifyTotpCode");
                //return Content(totpCode);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult VerifyTotpCode()
        {
            if (signInManager.IsSignedIn(User)) return RedirectToAction("Index", "Home");
            if (!TempData.ContainsKey("PTC")) return NotFound();

            var totpTempDataModel = JsonSerializer.Deserialize<PhoneTotpTempDataModel>(TempData["PTC"].ToString()!);
            if (totpTempDataModel.ExpirationTime <= DateTime.Now)
            {
                TempData["SendTotpCodeErrorMessage"] = "کد ارسال شده منقضی شده، لطفا کد جدیدی دریافت کنید.";
                return RedirectToAction("SendTotpCode");
            }

            TempData.Keep("PTC");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyTotpCode(VerifyTotpCodeViewModel model)
        {
            if (signInManager.IsSignedIn(User)) return RedirectToAction("Index", "Home");
            if (!TempData.ContainsKey("PTC")) return NotFound();
            if (ModelState.IsValid)
            {
                var totpTempDataModel = JsonSerializer.Deserialize<PhoneTotpTempDataModel>(TempData["PTC"].ToString()!);
                if (totpTempDataModel.ExpirationTime <= DateTime.Now)
                {
                    TempData["SendTotpCodeErrorMessage"] = "کد ارسال شده منقضی شده، لطفا کد جدیدی دریافت کنید.";
                    return RedirectToAction("SendTotpCode");
                }

                var user = await userManager.Users
                    .Where(u => u.PhoneNumber == totpTempDataModel.PhoneNumber)
                    .FirstOrDefaultAsync();

                var result = _phoneTotpProvider.VerifyTotp(totpTempDataModel.SecretKey, model.TotpCode);
                if (result.Succeeded)
                {
                    if (user == null)
                    {
                        TempData["SendTotpCodeErrorMessage"] = "کاربری با شماره موبایل وارد شده یافت نشد.";
                        return RedirectToAction("SendTotpCode");
                    }

                    if (!user.PhoneNumberConfirmed)
                    {
                        TempData["SendTotpCodeErrorMessage"] = "شماره موبایل شما تایید نشده است.";
                        return RedirectToAction("SendTotpCode");
                    }

                    if (!await userManager.IsLockedOutAsync(user))
                    {
                        await userManager.ResetAccessFailedCountAsync(user);
                        await signInManager.SignInAsync(user, false);
                        TempData.Remove("PTC");
                        return RedirectToAction("Index", "Home");
                    }

                    TempData["SendTotpCodeErrorMessage"] = "اکانت شما به دلیل ورود ناموفق تا مدت زمان معینی قفل شده است.";
                    return RedirectToAction("SendTotpCode");
                }

                if (user != null && user.PhoneNumberConfirmed && !await userManager.IsLockedOutAsync(user))
                {
                    await userManager.AccessFailedAsync(user);
                }

                TempData["SendTotpCodeErrorMessage"] = "کد ارسال شده معتبر نمی باشد، لطفا کد جدیدی دریافت کنید.";
                return RedirectToAction("SendTotpCode");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Account",
                new { ReturnUrl = returnUrl });

            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }
        public async Task<IActionResult> ExternalLoginCallBack(string returnUrl = null, string remoteError = null)
        {
            returnUrl =
                (returnUrl != null && Url.IsLocalUrl(returnUrl)) ? returnUrl : Url.Content("~/");

            var loginViewModel = new Login_Model()
            {
                ReturnURL = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError("", $"Error : {remoteError}");
                return View("Login", loginViewModel);
            }

            var externalLoginInfo = await signInManager.GetExternalLoginInfoAsync();
            if (externalLoginInfo == null)
            {
                ModelState.AddModelError("ErrorLoadingExternalLoginInfo", $"مشکلی پیش آمد");
                return View("Login", loginViewModel);
            }

            var signInResult = await signInManager.ExternalLoginSignInAsync(externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey, false, true);

            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl);
            }

            var email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);

            if (email != null)
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    var userName = email.Split('@')[0];
                    user = new User()
                    {
                        UserName= (userName.Length <= 10 ? userName : userName.Substring(0, 10)),
                        Email = email,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(user);
                }

                await userManager.AddLoginAsync(user, externalLoginInfo);
                await signInManager.SignInAsync(user, false);

                return Redirect(returnUrl);
            }

            ViewBag.ErrorTitle = "لطفا با بخش پشتیبانی تماس بگیرید";
            ViewBag.ErrorMessage = $"دریافت کرد {externalLoginInfo.LoginProvider} نمیتوان اطلاعاتی از";
            return View();
        }


    }
}