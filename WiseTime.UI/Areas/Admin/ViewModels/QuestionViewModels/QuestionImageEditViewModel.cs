using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WiseTime.UI.Areas.Admin.ViewModels.QuestionViewModels
{
    public class QuestionImageEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sual boş ola bilməz.")]
        [MaxLength(10000, ErrorMessage = "Sual 10000 hərfdən çox ola bilməz.")]
        [MinLength(20, ErrorMessage = "Sual 20 hərfdən az ola bilməz.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "A seçimi boş ola bilməz.")]
        public string OptionA { get; set; }
        [Required(ErrorMessage = "B seçimi boş ola bilməz.")]
        public string OptionB { get; set; }
        [Required(ErrorMessage = "C seçimi boş ola bilməz.")]
        public string OptionC { get; set; }
        [Required(ErrorMessage = "D seçimi boş ola bilməz.")]
        public string OptionD { get; set; }
        [Required(ErrorMessage = "E seçimi boş ola bilməz.")]
        public string OptionE { get; set; }
        [Required(ErrorMessage = "Düzgün cavab boş ola bilməz.")]
        public string CorrectOption { get; set; }
        public bool Status { get; set; }
        [Required(ErrorMessage = "Sualın balı boş ola bilməz.")]
        public decimal Point { get; set; }
        public int ExamTypeId { get; set; }
        public IFormFile ImageName { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
