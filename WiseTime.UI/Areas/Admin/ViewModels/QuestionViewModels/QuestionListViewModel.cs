using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WiseTime.UI.Areas.Admin.ViewModels.QuestionViewModels
{
    public class QuestionListViewModel
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
        public decimal Point { get; set; }
        public int ExamTypeId { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
