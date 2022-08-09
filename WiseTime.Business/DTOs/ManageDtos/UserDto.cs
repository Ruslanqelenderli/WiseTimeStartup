using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseTime.Business.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad Daxil edin.")]
        [MinLength(3,ErrorMessage ="Ad 2 hərfdən çox olmalıdır.")]
        [MaxLength(50,ErrorMessage ="Ad 50 hərfdən az olmalıdır.")]
        public string Name { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Soyad daxil edin.")]
        [MinLength(3, ErrorMessage = "Soyad 2 hərfdən çox olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Soyad 50 hərfdən az olmalıdır.")]
        public string Surname { get; set; }

        [MinLength(3, ErrorMessage = "Məktəb adı 2 hərfdən çox olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Məktəb adı 50 hərfdən az olmalıdır.")]
        public string SchoolName { get; set; }
        
        [MinLength(3, ErrorMessage = "Universitet adı 2 hərfdən çox olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Universitet adı 50 hərfdən az olmalıdır.")]
        public string UniversityName { get; set; }

        [Required(ErrorMessage = "Doğum tarixi qeyd edin.")]
        public DateTime Birthdate { get; set; }

        //[Required(ErrorMessage = "Cinsiyyət qeyd edin")]
        [MinLength(3, ErrorMessage = "Cinsiyyət 2 hərfdəm çox olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Cinsiyyət 50 hərfdən az olmalıdır.")]
        public string Gender { get; set; }

        [MinLength(3, ErrorMessage = "Fin 2 hərfdən çox olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Fin 50 hərfdən az olmalıdır.")]
        public string Fin { get; set; }

        [Required(ErrorMessage = "Telefon nömrəsi qeyd edin.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        public string Image { get; set; }

        [Required(ErrorMessage = "Şifrə daxil edin.")]
        [MinLength(6, ErrorMessage = "Şifrə 5 hərfdən çox olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Şifrə 50 hərfdən az olmalıdır.")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Email daxil edin.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }
        public string SecurityStamp { get; set; }
    }
}
