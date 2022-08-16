using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.UI.Areas.Admin.ViewModels.QuestionViewModels;
using WiseTime.UI.Areas.Admin.ViewModels.UserViewModels;
using WiseTime.UI.ViewModels;

namespace WiseTime.UI.Controllers
{
    public class TestController : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            var url = "http://localhost:57630/api/Question/GetByExamTypeId/"+id;
            var result = await Api.Api<QuestionListViewModel>.GetAsync(url);
            return View(result);
        }
        public IActionResult Result()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Result(QuestionListViewModel obj)
        {
            var model = new TestResultViewModel();
            var urluser = "http://localhost:57630/api/User";
            var users = await Api.Api<GetAllUserViewModel>.GetAsync(urluser);
            var user = users.FirstOrDefault(x => x.Email == User.Identity.Name);


            
            return View(obj);
        }


    }
}
