using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WiseTime.UI.Areas.Admin.ViewModels.CommentViewModel
{
    public class AddCommentViewModel
    {
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
