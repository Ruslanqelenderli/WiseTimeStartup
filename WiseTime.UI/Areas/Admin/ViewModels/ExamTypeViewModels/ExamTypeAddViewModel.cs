using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WiseTime.UI.Areas.Admin.ViewModels.ExamTypeViewModels
{
    public class ExamTypeAddViewModel
    {
        [Required(ErrorMessage = "Zəhmət olmasa ad daxil edin.")]
        [MaxLength(100, ErrorMessage = "Ad 100 hərfdən çox olmamalıdır.")]
        [MinLength(3, ErrorMessage = "Ad ən az 3 hərfdən ibarət olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa məzmun daxil edin.")]
        [MaxLength(10000, ErrorMessage = "Məzmun 10000 hərfdən çox olmamalıdır.")]
        [MinLength(20, ErrorMessage = "Məzmun ən az 20 hərfdən ibarət olmalıdır.")]
        public string Description { get; set; }
        public bool Status { get; set; }
        public int ExamId { get; set; }
    }
}
