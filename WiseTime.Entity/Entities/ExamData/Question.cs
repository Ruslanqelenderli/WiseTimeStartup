using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseTime.Entity.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string OptionE { get; set; }
        public string CorrectOption { get; set; }
        public bool Status { get; set; }
        public int ExamTypeId { get; set; }
        public decimal Point { get; set; }
        public string Image { get; set; }
        public ExamType ExamType { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
