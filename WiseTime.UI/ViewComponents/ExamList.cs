using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.UI.Areas.Admin.ViewModels.ExamViewModels;

namespace WiseTime.UI.ViewComponents
{
    public class ExamList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var urlexam = "http://localhost:57630/api/Exam/GetAll";
            var exams = Api.Api<ListExamViewModel>.GetAsync(urlexam);
            return View(exams.Result);
        }
    }
}
