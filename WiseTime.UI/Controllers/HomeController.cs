using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.UI.Areas.Admin.ViewModels.PostViewModels;

namespace WiseTime.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var posts = await Api.Api<GetAllPostViewModel>.GetAsync("http://localhost:57630/api/Post/");
            var trueposts = posts.Where(x => x.Status == true).ToList();
            ViewBag.Posts = trueposts.TakeLast(6);

            return View();
        }

        
    }
}
