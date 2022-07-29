using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Business.DTOs;

namespace WiseTime.UI.ViewComponents.Register
{
    public class Register:ViewComponent
    {
        public async  Task<IViewComponentResult> InvokeAsync(UserDto dto,string Password2)
        {
            return View();
            
           
        }
    }
}
