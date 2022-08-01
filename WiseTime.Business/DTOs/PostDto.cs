using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseTime.Business.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string TumbnailImage { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
