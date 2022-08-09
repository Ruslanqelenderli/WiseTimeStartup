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
    public class ExamTypeController : Controller
    {
        public async Task<IActionResult> Add(int id)
        {
            TempData["ExamId"] = id;
            var urlExamType = "http://localhost:57630/api/ExamType/";
            var urlExam = "http://localhost:57630/api/Exam/";
            var examTypes = await Api.Api<ExamTypeListViewModel>.GetAsync(urlExamType);
            var examTypesByExamId = examTypes.Where(x => x.ExamId == id).ToList();
            var exam = await Api.Api<ListExamViewModel>.GetAsync(urlExam + id);
            ViewBag.ExamName = exam.FirstOrDefault().Name;
            ViewBag.ExamTypes = examTypesByExamId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExamTypeAddViewModel model)
        {
            
                
            var urlExamType = "http://localhost:57630/api/ExamType/";
            if (!ModelState.IsValid)
            {
                var examTypess = await Api.Api<ExamTypeListViewModel>.GetAsync(urlExamType);
                var examTypesByExamIdd = examTypess.Where(x => x.ExamId == model.ExamId).ToList();

                ViewBag.ExamTypes = examTypesByExamIdd;
                TempData["ExamId"] = model.ExamId;
                return View(model);
            }
                

            
            var json = JsonConvert.SerializeObject(model);
            var response = await Api.Api<ExamTypeListViewModel>.PostAsync(urlExamType, json);

            var examTypes = await Api.Api<ExamTypeListViewModel>.GetAsync(urlExamType);
            var examTypesByExamId = examTypes.Where(x => x.ExamId == model.ExamId).ToList();

            ViewBag.ExamTypes = examTypesByExamId;
            if (response.IsSuccessStatusCode)
            {
                TempData["Added"] = "Əlavə edildi";
                return Redirect("/Admin/ExamType/Add/" + model.ExamId);
            }
            TempData["AddedError"] = "Xəta! Əlavə edilmədi.";
            return Redirect("/Admin/ExamType/Add/"+model.ExamId);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var urlExamType = "http://localhost:57630/api/ExamType/";
            var examType = await Api.Api<ExamTypeEditViewModel>.GetAsync(urlExamType + id);
            return View(examType.FirstOrDefault());

        }

        [HttpPost]
        public async Task<IActionResult> Edit(ExamTypeEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            var urlExamType = "http://localhost:57630/api/ExamType/";
            var json = JsonConvert.SerializeObject(model);
            var response = await Api.Api<ExamTypeListViewModel>.PutAsync(urlExamType,json);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Updated = "Dəyişiklər qeydə alındı.";
                return View();
            }
            ViewBag.UpdatedError = "Xəta! Dəyişiklər qeydə alınmadı.";
            return View();

        }
        public async Task<IActionResult> Remove(int id)
        {
            var urlexamtype = "http://localhost:57630/api/ExamType/";
            var urlquestion = "http://localhost:57630/api/Question/";

            var questions = await Api.Api<QuestionListViewModel>.GetAsync(urlquestion);
            var questionsbyexamtypeid = questions.Where(x => x.ExamTypeId == id).ToList();
            var allquestionremoveresponse = new List<HttpResponseMessage>();
            if (questionsbyexamtypeid.Count != 0)
            {
                foreach (var question in questionsbyexamtypeid)
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
                    return RedirectToAction("Add", "ExamType");
                }
            }

            var response = await Api.Api<ExamTypeListViewModel>.DeleteAsync(urlexamtype + id);


            if (response.IsSuccessStatusCode)
            {

                TempData["Deleted"] = "İmtahan növü silindi.";
                return RedirectToAction("Add", "ExamType");
            }
            TempData["DeletedError"] = "Xəta! İmtahan  silinmədi.";
            return RedirectToAction("Add", "ExamType");
        }
    }
}
