using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WiseTime.UI.ViewModels
{
    public class SendEmailForPasswordViewModel
    {
        [Required(ErrorMessage = "Email daxil edin.")]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$", ErrorMessage = "Email address is not valid yo")]
        public string Email { get; set; }
    }
}
