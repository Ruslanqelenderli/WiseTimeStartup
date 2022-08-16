using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Business.Abstract;
using WiseTime.Business.DTOs;
using WiseTime.Business.Email;
using WiseTime.Entity.Entities.Manage;
using WiseTime.UI.ViewModels;

namespace WiseTime.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IUserProjectService userprojectService;
        private readonly IMapper mapper;

        public AccountController(SignInManager<User> signInManager, IMapper mapper, UserManager<User> userManager, IUserProjectService userprojectService)
        {
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.userManager = userManager;
            this.userprojectService = userprojectService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)

        {
            if(ModelState.IsValid)
            {
                var urluser = "http://localhost:57630/api/User";
                var users = await Api.Api<UserDto>.GetAsync(urluser);

                if (users != null)
                {
                    foreach (var item in users)
                    {
                        if (item.Email == model.Email)
                        {
                            var user = mapper.Map<User>(item);
                            if (userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) != PasswordVerificationResult.Failed)
                            {
                                if (item.EmailConfirmed)
                                {

                                    var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);
                                    if (result.Succeeded)
                                    {
                                        return RedirectToAction("Index", "Home");
                                    }
                                    else
                                    {
                                        return RedirectToAction("Error", "Home");
                                    }
                                }
                                else
                                {
                                    ViewBag.EmailConfrmed = "Email təstiq olunmayıb";
                                    return View(model);
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("Password", "Şifrə səhvdir");
                                return View(model);
                            }

                        }
                    }
                    ModelState.AddModelError("Email", "Email səhvdir");
                    return View(model);
                }
                return RedirectToAction("Error", "Home");
            }
            return View(model);
            
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserDto dto, string Password2)
        {
            if (ModelState.IsValid)
            {
                if (dto.PasswordHash == Password2)
                {
                    
                        dto.Image = "image";
                        dto.EmailConfirmed = false;
                        var urluser = "http://localhost:57630/api/User";


                        var users = await Api.Api<UserDto>.GetAsync(urluser);

                        foreach (var item in users)
                        {
                            if (item.Email == dto.Email)
                            {
                                ViewBag.Email = "Bu email ilə qeydiyyatdan keçilib";
                                return View(dto);
                            }
                        }
                        var json = JsonConvert.SerializeObject(dto);
                         
                        var response = await Api.Api<UserDto>.PostAsync(urluser, json);

                        if (response.IsSuccessStatusCode)
                        {
                            TempData["Email"] = dto.Email;
                            return RedirectToAction("CreateEmailToken", "Email");
                        }
                        else
                        {
                            return RedirectToAction("Login", "Account");
                        }
                    
                   
                }
                ModelState.AddModelError("Password2", "Şifrə yalnışdır.");
                return View(dto);
            }
            return View(dto);


        }

        public async Task<IActionResult> Logout()
        {
             await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult SendEmailForPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendEmailForPassword(SendEmailForPasswordViewModel viewModel)
        {
            var email = viewModel.Email;
            var returnResult = await userprojectService.GetByEmail(email);
            var dto = returnResult.List.FirstOrDefault();
            if (dto!=null)
            {
                
                if (dto.EmailConfirmed)
                {
                    var resetpasswordLink = Url.Action("ResetPassword", "Account", new { email = dto.Email }, Request.Scheme);
                    var subject = "Şifrə yeniləmə tələbi";
                    EmailHelper emailHelper = new EmailHelper();
                    bool emailResponse = emailHelper.SendEmail(dto.Email, subject, resetpasswordLink);
                    if (emailResponse)
                    {
                        TempData["EmailForResetPassword"] = "Emailinizə tələb göndərildi";
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        TempData["EmailForResetPassword"] = "Emailinizə tələb göndərilmədi.";
                        return RedirectToAction("Login", "Account");
                    }
                }
                ViewBag.EmailConfirmed = "Bu email təstiq olunmayıb.";
                return View(viewModel);
            }
            ViewBag.Email = "Bu email yalnışdır.";
            return View(viewModel);
        }
        public IActionResult ResetPassword(string email)
        {
          
                var model = new ResetPasswordVewModel() { Email = email };
               
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVewModel viewModel,string Password2)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            if (viewModel.Password != Password2)
            {
                ModelState.AddModelError("Password2", "Şifrə düzgün deyil");
            }
            var email = viewModel.Email;
            var returnResult = await userprojectService.GetByEmail(email);
            var dto = returnResult.List.FirstOrDefault();
            dto.PasswordHash = viewModel.Password;
            var urluser = "http://localhost:57630/api/User";
            var json = JsonConvert.SerializeObject(dto);

            var response = await Api.Api<UserDto>.PutAsync(urluser, json);

            if (response.IsSuccessStatusCode)
            {
                TempData["ResetPassword"] = "Şifrə dəyişdirildi.";
                return RedirectToAction("Login", "Account");
            }
            else
            {
                TempData["ResetPassword"] = "Xəta.Şifrə dəyişdirilmədi.";
                return RedirectToAction("Login", "Account");
            }


        }


    }
}
