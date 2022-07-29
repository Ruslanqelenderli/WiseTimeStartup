using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.Business.DTOs;
using WiseTime.UI.Areas.Admin.ViewModels.CategoryViewModels;
using WiseTime.UI.Areas.Admin.ViewModels.PostViewModels;

namespace WiseTime.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public async Task<IActionResult> Add()
        {
            var urlpost = "http://localhost:57630/api/Post";
            var posts = await Api.Api<GetAllPostViewModel>.GetAsync(urlpost);
            var urlcategory = "http://localhost:57630/api/Category";
            var categories = await Api.Api<CategoryListViewModel>.GetAsync(urlcategory);
            ViewBag.Categories = categories;
            ViewBag.Posts = posts;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddPostViewModel model)
        {
            var urlpost = "http://localhost:57630/api/Post";
            var urlcategory = "http://localhost:57630/api/Category";
            var posts = await Api.Api<GetAllPostViewModel>.GetAsync(urlpost);
            var categories = await Api.Api<CategoryListViewModel>.GetAsync(urlcategory);
            ViewBag.Categories = categories;
            ViewBag.Posts = posts;


            if (!ModelState.IsValid)
            { 
                return View(model);
            }

            if (model.Image == null)
            {
                ModelState.AddModelError("ImageNull", "Şəkil seçin");
                return View(model);
            }
            else if (model.TumbnailImage == null)
            {
                ModelState.AddModelError("TumbnailImageNull", "Profil şəkli seçin");
                return View(model);
            }
            else if (model.CategoryId==0)
            {
                ModelState.AddModelError("Category", "Kateqoriya seçin");
                return View(model);
            }
            else
            {
                var extensionImage = Path.GetExtension(model.Image.FileName);
                var newimagename = Guid.NewGuid() + extensionImage;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Image/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                model.Image.CopyTo(stream);

                var extensionTumbnailImage = Path.GetExtension(model.TumbnailImage.FileName);
                var newtumbnailimagename = Guid.NewGuid() + extensionTumbnailImage;
                var location2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/TumbnailImage/", newtumbnailimagename);
                var stream2 = new FileStream(location2, FileMode.Create);
                model.Image.CopyTo(stream2);

                var imagemodel = new AddPostImageViewModel();
                imagemodel.Image = newimagename;
                imagemodel.CategoryId = model.CategoryId;
                imagemodel.Content = model.Content;
                imagemodel.Status = model.Status;
                imagemodel.Title = model.Title;
                imagemodel.TumbnailImage = newtumbnailimagename;
                imagemodel.UserId = 14;




                var json = JsonConvert.SerializeObject(imagemodel);
                var response = await Api.Api<AddPostViewModel>.PostAsync(urlpost, json);
                if (response.IsSuccessStatusCode)
                {
                    var postswithnew = await Api.Api<GetAllPostViewModel>.GetAsync(urlpost);
                    ViewBag.Posts = postswithnew;
                    ViewBag.Added = "Əlavə edildi.";
                    return View();
                }
                ViewBag.Error = "Error.......";
                return View();
            }
            
        }


        public async Task<IActionResult> Remove(int id)
        {
            var urlpost = "http://localhost:57630/api/Post/"+id;
            var response = await Api.Api<GetAllPostViewModel>.DeleteAsync(urlpost);
            if (response.IsSuccessStatusCode)
            {
                TempData["DeletePost"] = "Post silindi.";
                return RedirectToAction("Add", "Blog");
            }
            TempData["DeletePost"] = "Post silinmədi.";
            return RedirectToAction("Add", "Blog");
        }


        public async Task<IActionResult> Details(int id)
        {
            var urlpost = "http://localhost:57630/api/Post/"+id;
            var post= await Api.Api<GetAllPostViewModel>.GetAsync(urlpost);
            if (post== null)
            {
                return View();
            }
            return View(post);
        }
    }
}
