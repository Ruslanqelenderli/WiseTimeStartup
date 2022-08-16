using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.UI.Areas.Admin.ViewModels.ExamTypeViewModels;

namespace WiseTime.UI.Areas.Admin.ViewModels.ExamViewModels
{
    public class ListExamViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<ExamTypeListViewModel> ExamTypes { get; set; }
    }
}
