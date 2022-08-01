using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WiseTime.UI.Areas.Admin.ViewModels.UserViewModels
{
    public class GetAllUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        
        public string Surname { get; set; }

        
        public string SchoolName { get; set; }

        
        public string UniversityName { get; set; }

        
        public DateTime Birthdate { get; set; }

        //[Required(ErrorMessage = "Cinsiyyət qeyd edin")]
        
        public string Gender { get; set; }

        
        public string Fin { get; set; }

        
        public string PhoneNumber { get; set; }


        public string Image { get; set; }

        
        public string PasswordHash { get; set; }

        
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }
        public string SecurityStamp { get; set; }
    }
}
