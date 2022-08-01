using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.UI.Areas.Admin.ViewModels.CategoryViewModels;

namespace WiseTime.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Add()
        {
            var category = await Api.Api<CategoryListViewModel>.GetAsync("http://localhost:57630/api/Category");
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddViewModel model)
        {
            
            if (!ModelState.IsValid)
                return View(model);
            var json = JsonConvert.SerializeObject(model);
            var response = await Api.Api<CategoryListViewModel>.PostAsync("http://localhost:57630/api/Category",json);
            var category = await Api.Api<CategoryListViewModel>.GetAsync("http://localhost:57630/api/Category");
            ViewBag.Category = category;
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
            var urlcategory = "http://localhost:57630/api/Category/";

            var category = await Api.Api<CategoryListViewModel>.GetAsync(urlcategory);
            var response = await Api.Api<CategoryListViewModel>.DeleteAsync(urlcategory+id);
            if (response.IsSuccessStatusCode)
            {

                TempData["Deleted"] = "Kateqoriya silindi.";
                return RedirectToAction("Add", "Category");
            }
            TempData["DeletedError"] = "Xəta! Kateqoriya silinmədi.";
            return RedirectToAction("Add", "Category");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var urlcategory="http://localhost:57630/api/Category/";
            var category = await Api.Api<CategoryEditViewModel>.GetAsync(urlcategory + id);
            return View(category.FirstOrDefault());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var urlcategory = "http://localhost:57630/api/Category";
            var json = JsonConvert.SerializeObject(model);
            var response = await Api.Api<CategoryListViewModel>.PutAsync(urlcategory, json);

            var category = await Api.Api<CategoryListViewModel>.GetAsync(urlcategory);
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
