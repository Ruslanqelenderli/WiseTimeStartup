using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WiseTime.UI.Areas.Admin.ViewModels.PostViewModels
{
    public class AddPostImageViewModel
    {
        
        public string Title { get; set; }
        public string Content { get; set; }
        public string TumbnailImage { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
