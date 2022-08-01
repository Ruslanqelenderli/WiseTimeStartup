using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.Business.DTOs;
using WiseTime.UI.Areas.Admin.ViewModels.CategoryViewModels;
using WiseTime.UI.Areas.Admin.ViewModels.CommentReplyViewModel;
using WiseTime.UI.Areas.Admin.ViewModels.CommentViewModel;
using WiseTime.UI.Areas.Admin.ViewModels.PostViewModels;
using WiseTime.UI.Areas.Admin.ViewModels.UserViewModels;

namespace WiseTime.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private IWebHostEnvironment Environment;
        public BlogController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
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
            var urluser = "http://localhost:57630/api/User";
            var users = await Api.Api<GetAllUserViewModel>.GetAsync(urluser);
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
            else if (model.CategoryId == 0)
            {
                ModelState.AddModelError("Category", "Kateqoriya seçin");
                return View(model);
            }
            else
            {
                var extensionImage = Path.GetExtension(model.Image.FileName);
                var newimagename = Guid.NewGuid() + extensionImage;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Image/", newimagename);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }
                



                var extensionTumbnailImage = Path.GetExtension(model.TumbnailImage.FileName);
                var newtumbnailimagename = Guid.NewGuid() + extensionTumbnailImage;
                var location2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/TumbnailImage/", newtumbnailimagename);
                using (var stream2 = new FileStream(location2, FileMode.Create))
                {
                    model.TumbnailImage.CopyTo(stream2);
                }
                

                var imagemodel = new AddPostImageViewModel();
                imagemodel.Image = newimagename;
                imagemodel.CategoryId = model.CategoryId;
                imagemodel.Content = model.Content;
                imagemodel.Status = model.Status;
                imagemodel.Title = model.Title;
                imagemodel.TumbnailImage = newtumbnailimagename;
                imagemodel.UserId = users.FirstOrDefault(x => x.Email == User.Identity.Name).Id;





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
            var urlpost = "http://localhost:57630/api/Post/" + id;
            var post = await Api.Api<GetAllPostViewModel>.GetAsync(urlpost);

            var urlcomment = "http://localhost:57630/api/Comment/";
            var comments = await Api.Api<GetAllCommentViewModel>.GetAsync(urlcomment);

            var urlcommentreply = "http://localhost:57630/api/CommentReply/";
            var commentreplies = await Api.Api<GetAllCommentReplyViewModel>.GetAsync(urlcommentreply);



            foreach (var commentreply in commentreplies)
            {
                if (commentreply.PostId == post.FirstOrDefault().Id)
                {
                    var commentresponse = await Api.Api<GetAllCommentReplyViewModel>.DeleteAsync(urlcommentreply + commentreply.Id);
                }
            }

            foreach (var comment in comments)
            {
                if (comment.PostId == post.FirstOrDefault().Id)
                {
                    var commentresponse = await Api.Api<GetAllCommentViewModel>.DeleteAsync(urlcomment + comment.Id);
                }
            }

            var response = await Api.Api<GetAllPostViewModel>.DeleteAsync(urlpost);
            if (response.IsSuccessStatusCode)
            {
                var locationimage = "wwwroot/Images/Image/" + post.FirstOrDefault().Image;
                var locationtumbnailimage = "wwwroot/Images/TumbnailImageImage/" + post.FirstOrDefault().Image;


                if (System.IO.File.Exists(locationimage))
                {
                   
                    System.IO.File.Delete(locationimage);
                }
                if (System.IO.File.Exists(locationtumbnailimage))

                {
                    var stream = new FileStream(locationtumbnailimage, FileMode.Truncate);
                    System.IO.File.Delete(locationtumbnailimage);
                }


                TempData["DeletePost"] = "Post silindi.";
                return RedirectToAction("Add", "Blog");
            }
            TempData["DeletePost"] = "Post silinmədi.";
            return RedirectToAction("Add", "Blog");
        }


        public async Task<IActionResult> Details(int id)
        {
            var urlpost = "http://localhost:57630/api/Post/" + id;
            var post = await Api.Api<GetAllPostViewModel>.GetAsync(urlpost);
            var posts = await Api.Api<GetAllPostViewModel>.GetAsync("http://localhost:57630/api/Post/");
            var user = await Api.Api<GetAllUserViewModel>.GetAsync("http://localhost:57630/api/User/" + post.FirstOrDefault().UserId);
            var lastposts = posts.TakeLast(2);
            var urlcommentforpostid = "http://localhost:57630/api/Comment/" + post.FirstOrDefault().Id;
            var comments = await Api.Api<GetAllCommentViewModel>.GetAsync(urlcommentforpostid);
            var users = await Api.Api<GetAllUserViewModel>.GetAsync("http://localhost:57630/api/User");

            var commentreplies = new List<GetAllCommentReplyViewModel>();
            foreach (var comment in comments)
            {
                var commentreply = await Api.Api<GetAllCommentReplyViewModel>.GetAsync("http://localhost:57630/api/CommentReply/" + comment.Id);
                if (commentreply != null)
                {
                    foreach (var item in commentreply)
                    {
                        commentreplies.Add(item);
                    }
                }
            }
            ViewBag.CommentReply = commentreplies;
            ViewBag.Users = users;
            ViewBag.Comments = comments;
            ViewBag.CommentCount = commentreplies.Count + comments.Count;
            ViewBag.LastPosts = lastposts;
            ViewBag.UserName = user.FirstOrDefault().Name + " " + user.FirstOrDefault().Surname;
            if (post == null)
            {
                return View();
            }
            return View(post.FirstOrDefault());
        }

        public async Task<IActionResult> Edit(int id)
        {
            var urlpost = "http://localhost:57630/api/Post/" + id;
            var post = await Api.Api<EditPostViewModel>.GetAsync(urlpost);
            var urlcategory = "http://localhost:57630/api/Category";
            var categories = await Api.Api<CategoryListViewModel>.GetAsync(urlcategory);
            ViewBag.Categories = categories;
            if (post == null)
            {
                return View();
            }
            return View(post.FirstOrDefault());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditPostViewModel model)
        {
            var urluser = "http://localhost:57630/api/User";
            var users = await Api.Api<GetAllUserViewModel>.GetAsync(urluser);
            var urlcategory = "http://localhost:57630/api/Category";
            var categories = await Api.Api<CategoryListViewModel>.GetAsync(urlcategory);
            ViewBag.Categories = categories;
            if (ModelState.IsValid)
            {
                var modelimage = new EditPostImageViewModel();
                string newimagename = null;
                string newtumbnailimagename = null;

                if (model.ImageIFF != null)
                {
                    if (System.IO.File.Exists(@"C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\wwwroot\Images\Image\" + model.Image))
                    {
                        System.IO.File.Delete(@"C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\wwwroot\Images\Image\" + model.Image);

                    }
                    var extensionImage = Path.GetExtension(model.ImageIFF.FileName);
                    newimagename = Guid.NewGuid() + extensionImage;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Image/", newimagename);
                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        model.ImageIFF.CopyTo(stream);
                    }
                    

                }

                if (model.TumbnailImageIFF != null)
                {


                    if (System.IO.File.Exists(@"C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\wwwroot\Images\TumbnailImage\" + model.TumbnailImage))
                    {

                        System.IO.File.Delete(@"C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\wwwroot\Images\TumbnailImage\" + model.TumbnailImage);

                    }
                    var extensionTumbnailImage = Path.GetExtension(model.TumbnailImageIFF.FileName);
                    newtumbnailimagename = Guid.NewGuid() + extensionTumbnailImage;
                    var location2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/TumbnailImage/", newtumbnailimagename);
                    var stream2 = new FileStream(location2, FileMode.Create);
                    model.TumbnailImageIFF.CopyTo(stream2);
                }
                modelimage.Id = model.Id;
                modelimage.EditDate = DateTime.Now;
                modelimage.Content = model.Content;
                modelimage.CategoryId = model.CategoryId;
                modelimage.CreateDate = model.CreateDate;
                modelimage.Title = model.Title;
                modelimage.UserId = users.FirstOrDefault(x => x.Email == User.Identity.Name).Id;
                modelimage.Image = newimagename ?? model.Image;
                modelimage.TumbnailImage = newtumbnailimagename ?? model.TumbnailImage;
                modelimage.Status = model.Status;

                var urlpost = "http://localhost:57630/api/Post";
                var json = JsonConvert.SerializeObject(modelimage);
                var response = await Api.Api<GetAllPostViewModel>.PutAsync(urlpost, json);
                if (response.IsSuccessStatusCode)
                {

                    var postswithnew = await Api.Api<GetAllPostViewModel>.GetAsync(urlpost);
                    ViewBag.Posts = postswithnew;
                    TempData["Edit"] = "Dəyişiklik qeydə alındı.";
                    return RedirectToAction("Add", "Blog");
                }
                ViewBag.Error = "Error.......";

                return View();
            }


            return View(model);
        }

    }
}
