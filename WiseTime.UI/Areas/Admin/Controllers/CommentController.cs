using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.UI.Areas.Admin.ViewModels.CommentViewModel;
using WiseTime.UI.Areas.Admin.ViewModels.UserViewModels;

namespace WiseTime.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public async Task<PartialViewResult> AddPartial(int id)
        {
            ViewBag.PostId = id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddPartial(AddCommentViewModel model,int id)
        {
            model.CreateDate = DateTime.Now;
            var users = await Api.Api<GetAllUserViewModel>.GetAsync("http://localhost:57630/api/User/");
            model.UserId = users.FirstOrDefault(x => x.Email == User.Identity.Name).Id;
            model.PostId = id;
            var json = JsonConvert.SerializeObject(model);
            var response = await Api.Api<AddCommentViewModel>.PostAsync("http://localhost:57630/api/User/", json);
            if (response.IsSuccessStatusCode)
            {
                return PartialView();
            }
            return NotFound();
            
        }
    }
}
