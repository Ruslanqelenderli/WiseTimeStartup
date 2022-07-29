using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.Business.Abstract;
using WiseTime.Business.Concrete.Manager;
using WiseTime.Business.DTOs;
using WiseTime.Business.Email;
using WiseTime.Entity.Entities.Manage;

namespace WiseTime.UI.Controllers
{
    public class EmailController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IUserProjectService userprojectService;
        public EmailController(UserManager<User> usrMgr, IUserProjectService userprojectService)
        {
            userManager = usrMgr;
            this.userprojectService = userprojectService;
        }

        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return NotFound();

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return RedirectToAction("Login","Account");
            }
            return View();
        }

        public async Task<IActionResult> CreateEmailToken()
        {
            var email = TempData["Email"].ToString();
            var returnResult = await userprojectService.GetByEmail(email);
            var dto =  returnResult.List.FirstOrDefault();
            var token = await userprojectService.GenerateToken(dto);
            var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = dto.Email }, Request.Scheme);
            var subject = "Email təstiqləmə tələbi";
            EmailHelper emailHelper = new EmailHelper();
            bool emailResponse = emailHelper.SendEmail(dto.Email,subject, confirmationLink);
            if (emailResponse)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
            
        }
        
    }
}
