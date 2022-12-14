using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Entity.Entities.Manage;

namespace WiseTime.Entity.Entities
{
    public class AnswerComment
    {
        [Key]
        public int Id { get; set; }
        
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

        public Comment Comment { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
