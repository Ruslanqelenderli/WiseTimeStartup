using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseTime.Entity.Entities
{
    public class ExamType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public Exam Exam { get; set; }
        public int ExamId { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
