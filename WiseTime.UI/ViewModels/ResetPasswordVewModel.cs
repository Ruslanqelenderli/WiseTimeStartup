using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WiseTime.UI.ViewModels
{
    public class ResetPasswordVewModel
    {
        [Required(ErrorMessage = "Şifrə daxil edin.")]
        [MinLength(6, ErrorMessage = "Şifrə 5 hərfdən çox olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Şifrə 50 hərfdən az olmalıdır.")]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
