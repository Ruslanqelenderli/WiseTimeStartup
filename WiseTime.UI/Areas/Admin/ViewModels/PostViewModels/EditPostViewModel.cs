using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WiseTime.UI.Areas.Admin.ViewModels.PostViewModels
{
    public class EditPostViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Başlıq boş buraxıla bilməz.")]
        [MaxLength(50, ErrorMessage = "Başlıq 50 hərfdən çox olmamalıdır.")]
        [MinLength(5, ErrorMessage = "Başlıq 6 hərfdən az olmamalıdır.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Məzmun boş buraxıla bilməz.")]
        [MaxLength(30000, ErrorMessage = "Məzmun 30000 hərfdən çox olmamalıdır.")]
        [MinLength(130, ErrorMessage = "Məzmun 131 hərfdən az olmamalıdır.")]
        public string Content { get; set; }
        public string TumbnailImage { get; set; }
        public IFormFile TumbnailImageIFF { get; set; }
        public string Image { get; set; }
        public IFormFile ImageIFF { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }

        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
