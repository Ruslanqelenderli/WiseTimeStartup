using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WiseTime.UI.Areas.Admin.ViewModels.PostViewModels
{
    public class AddPostViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile TumbnailImage { get; set; }
        public IFormFile Image { get; set; }
        public bool Status { get; set; }
        [Required(ErrorMessage ="Kateqoriya seçin")]
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
