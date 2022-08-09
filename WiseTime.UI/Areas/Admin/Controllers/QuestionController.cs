using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.UI.Areas.Admin.ViewModels.ExamTypeViewModels;
using WiseTime.UI.Areas.Admin.ViewModels.QuestionViewModels;

namespace WiseTime.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        public async Task<IActionResult> Add(int id)
        {
            ViewData["ExamTypeId"] = id;
            var urlquestion = "http://localhost:57630/api/Question/";
            var urlExamType = "http://localhost:57630/api/ExamType/";
            var examQuestions = await Api.Api<QuestionListViewModel>.GetAsync(urlquestion);
            var examQuestionsByExamType = examQuestions.Where(x => x.ExamTypeId == id).ToList();
            var examType = await Api.Api<ExamTypeListViewModel>.GetAsync(urlExamType + id);
            ViewBag.ExamTypeName = examType.FirstOrDefault().Name;
            ViewBag.Questions = examQuestionsByExamType;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(QuestionImageAddViewModel modelimage)
        {
            var urlQuestion = "http://localhost:57630/api/Question/";


            if (!ModelState.IsValid)
            {
                var questionss = await Api.Api<QuestionListViewModel>.GetAsync(urlQuestion);
                var questionsByExamTypeIdd = questionss.Where(x => x.ExamTypeId == modelimage.ExamTypeId).ToList();

                ViewBag.Questions = questionsByExamTypeIdd;
                ViewData["ExamTypeId"] = modelimage.ExamTypeId;
                return View(modelimage);
            }

            string newimagename = null;
            if (modelimage.Image != null)
            {
                var extensionImage = Path.GetExtension(modelimage.Image.FileName);
                newimagename = Guid.NewGuid() + extensionImage;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/QuestionImage/", newimagename);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    modelimage.Image.CopyTo(stream);
                }
            }

            QuestionAddViewModel model = new QuestionAddViewModel();
            model.CorrectOption = modelimage.CorrectOption;
            model.ExamTypeId = modelimage.ExamTypeId;
            model.Image = newimagename;
            model.OptionA = modelimage.OptionA;
            model.OptionB = modelimage.OptionB;
            model.OptionC = modelimage.OptionC;
            model.OptionD = modelimage.OptionD;
            model.OptionE = modelimage.OptionE;
            model.Point = modelimage.Point;
            model.Status = modelimage.Status;
            model.Title = modelimage.Title;


            var json = JsonConvert.SerializeObject(model);
            var response = await Api.Api<QuestionListViewModel>.PostAsync(urlQuestion, json);

            var questions = await Api.Api<QuestionListViewModel>.GetAsync(urlQuestion);
            var questionsByExamTypeId = questions.Where(x => x.ExamTypeId == model.ExamTypeId).ToList();

            ViewBag.Questions = questionsByExamTypeId;
            if (response.IsSuccessStatusCode)
            {
                TempData["Added"] = "Əlavə edildi";
                return Redirect("/Admin/Question/Add/" + modelimage.ExamTypeId);
            }
            TempData["AddedError"] = "Xəta! Əlavə edilmədi.";
            return Redirect("/Admin/Question/Add/" + modelimage.ExamTypeId);

        }
        public readonly static string[] Option = { "A", "B", "C", "D", "E" };
        public async Task<IActionResult> Edit(int id)
        {
            var urlQuestion = "http://localhost:57630/api/Question/";
            var question = await Api.Api<QuestionImageEditViewModel>.GetAsync(urlQuestion + id);
            TempData["Options"] = Option;
            return View(question.FirstOrDefault());

        }

        [HttpPost]
        public async Task<IActionResult> Edit(QuestionImageEditViewModel modelimage)
        {
            if (!ModelState.IsValid)
                return View(modelimage);


            var urlQuestion = "http://localhost:57630/api/Question/";
            string newimagename = null;
            if (modelimage.ImageName != null)
            {
                if (System.IO.File.Exists(@"C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\wwwroot\Images\QuestionImage\" + modelimage.Image))
                {
                    System.IO.File.Delete(@"C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\wwwroot\Images\QuestionImage\" + modelimage.Image);

                }
                var extensionImage = Path.GetExtension(modelimage.ImageName.FileName);
                newimagename = Guid.NewGuid() + extensionImage;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/QuestionImage/", newimagename);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    modelimage.ImageName.CopyTo(stream);
                }


            }

            QuestionEditViewModel model = new QuestionEditViewModel();
            model.CorrectOption = modelimage.CorrectOption;
            model.CorrectOption = modelimage.CorrectOption;
            model.ExamTypeId = modelimage.ExamTypeId;
            model.Image = newimagename ?? modelimage.Image;
            model.OptionA = modelimage.OptionA;
            model.OptionB = modelimage.OptionB;
            model.OptionC = modelimage.OptionC;
            model.OptionD = modelimage.OptionD;
            model.OptionE = modelimage.OptionE;
            model.Point = modelimage.Point;
            model.Status = modelimage.Status;
            model.Title = modelimage.Title;
            model.Id = modelimage.Id;


            var json = JsonConvert.SerializeObject(model);
            var response = await Api.Api<QuestionListViewModel>.PutAsync(urlQuestion, json);

            if (response.IsSuccessStatusCode)
            {
                TempData["Update"] = "Dəyişiklər qeydə alındı.";
                TempData["Options"] = Option;
                return Redirect("/Admin/Question/Edit/"+model.Id);
            }
            TempData["UpdateError"] = "Xəta! Dəyişiklər qeydə alınmadı.";
            TempData["Options"] = Option;
            return Redirect("/Admin/Question/Edit/" + model.Id);

        }
        public async Task<IActionResult> Remove(int id)
        {
            var urlexam = "http://localhost:57630/api/Question/";
            var question = await Api.Api<QuestionListViewModel>.GetAsync(urlexam + id);
            var response = await Api.Api<QuestionListViewModel>.DeleteAsync(urlexam + id);

            if (System.IO.File.Exists(@"C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\wwwroot\Images\QuestionImage\" + question.FirstOrDefault().Image))
            {
                System.IO.File.Delete(@"C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\wwwroot\Images\QuestionImage\" + question.FirstOrDefault().Image);

            }
            if (response.IsSuccessStatusCode)
            {

                TempData["Deleted"] = "Sual silindi.";
                return Redirect("/Admin/Question/Add/"+question.FirstOrDefault().ExamTypeId);
            }
            TempData["DeletedError"] = "Xəta! Sual silinmədi.";
            return Redirect("/Admin/Question/Add/" + question.FirstOrDefault().ExamTypeId);
        }
    }
}
