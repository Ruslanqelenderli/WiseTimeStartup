using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseTime.Business.DTOs
{
    public class CommentDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }
    }
}
