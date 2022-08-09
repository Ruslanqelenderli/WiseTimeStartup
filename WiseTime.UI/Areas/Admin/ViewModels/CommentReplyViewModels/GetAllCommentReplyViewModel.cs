using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WiseTime.UI.Areas.Admin.ViewModels.CommentReplyViewModel
{
    public class GetAllCommentReplyViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public int PostId { get; set; }

    }
}
