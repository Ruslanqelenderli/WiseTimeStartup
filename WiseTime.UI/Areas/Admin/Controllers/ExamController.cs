using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WiseTime.UI.Areas.Admin.ViewModels.ExamTypeViewModels;
using WiseTime.UI.Areas.Admin.ViewModels.ExamViewModels;
using WiseTime.UI.Areas.Admin.ViewModels.QuestionViewModels;

namespace WiseTime.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExamController : Controller
    {
        public async Task<IActionResult> Add()
        {
            var urlexam = "http://localhost:57630/api/Exam";
            var exams = await Api.Api<ListExamViewModel>.GetAsync(urlexam);
            ViewBag.Exam = exams;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ExamAddViewModel model)
        {

            var urlexam = "http://localhost:57630/api/Exam";

            if (!ModelState.IsValid)
                return View(model);
            var json = JsonConvert.SerializeObject(model);
            var response = await Api.Api<ListExamViewModel>.PostAsync(urlexam, json);
            var exams = await Api.Api<ListExamViewModel>.GetAsync(urlexam);
            ViewBag.Exam = exams;
            if (response.IsSuccessStatusCode)
            {

                ViewBag.Added = "Əlavə edildi";
                return View();
            }
            ViewBag.AddedError = "Xəta! Əlavə edilmədi.";
            return View();
        }
        public async Task<IActionResult> Remove(int id)
        {
            var urlexam = "http://localhost:57630/api/Exam/";
            var urlexamtype = "http://localhost:57630/api/ExamType/";
            var urlquestion = "http://localhost:57630/api/Question/";
            var examtypes = await Api.Api<ExamTypeListViewModel>.GetAsync(urlexamtype);
            var examtypesbyexamid = examtypes.Where(x => x.ExamId == id).ToList();
            var questions = await Api.Api<QuestionListViewModel>.GetAsync(urlquestion);

            var questionbyexamtypeid = new List<QuestionListViewModel>();

            foreach (var question in questions)
            {
                foreach (var examtype in examtypesbyexamid)
                {
                    if (question.ExamTypeId == examtype.Id)
                    {
                        questionbyexamtypeid.Add(question);
                    }
                }
            }


            var allquestionremoveresponse = new List<HttpResponseMessage>();
            if (questionbyexamtypeid.Count != 0)
            {
                foreach (var question in questionbyexamtypeid)
                {
                   

                    var questionremoveresponse = await Api.Api<QuestionListViewModel>.DeleteAsync(urlquestion + question.Id);
                    allquestionremoveresponse.Add(questionremoveresponse);
                }
            }

            foreach (var removeresponse in allquestionremoveresponse)
            {
                if (!removeresponse.IsSuccessStatusCode)
                {
                    TempData["DeletedQuestionError"] = "Xəta . İmtahan silinərkən sual silinmə xətası.";
                    return RedirectToAction("Add", "Exam");
                }
            }
            var allexamtyperemoveresponse = new List<HttpResponseMessage>();
            foreach (var examType in examtypesbyexamid)
            {
                var examtyperemoveresponse = await Api.Api<ExamTypeListViewModel>.DeleteAsync(urlexamtype + examType.Id);
                allexamtyperemoveresponse.Add(examtyperemoveresponse);
            }
            foreach (var removeresponse in allexamtyperemoveresponse)
            {
                if (!removeresponse.IsSuccessStatusCode)
                {
                    TempData["DeletedExamTypeError"] = "Xəta . İmtahan silinərkən imtahan növü silinmə xətası.";
                    return RedirectToAction("Add", "Exam");
                }
            }

            var response = await Api.Api<ListExamViewModel>.DeleteAsync(urlexam + id);
            if (response.IsSuccessStatusCode)
            {

                TempData["Deleted"] = "İmtahan silindi.";
                return RedirectToAction("Add", "Exam");
            }
            TempData["DeletedError"] = "Xəta! İmtahan  silinmədi.";
            return RedirectToAction("Add", "Exam");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var urlexam = "http://localhost:57630/api/Exam/";
            var exam = await Api.Api<ExamEditViewModel>.GetAsync(urlexam + id);
            return View(exam.FirstOrDefault());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ExamEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var urlexam = "http://localhost:57630/api/Exam/";
            var json = JsonConvert.SerializeObject(model);
            var response = await Api.Api<ListExamViewModel>.PutAsync(urlexam, json);

            
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Updated = "Dəyişiklər qeydə alındı.";
                return View();
            }
            ViewBag.UpdatedError = "Xəta! Dəyişiklər qeydə alınmadı.";
            return View();
        }
    }
}
