using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.Business.Abstract;
using WiseTime.Business.DTOs;
using WiseTime.Business.Email;
using WiseTime.Entity.Entities.Manage;

namespace WiseTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase

    {
        private readonly IUserProjectService userProjectService;

        public UserController(IUserProjectService userProjectService)
        {
            this.userProjectService = userProjectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            var result = await userProjectService.GetAll();
            if (result.Result)
            {
                return Ok(result.List);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {

            var result = await userProjectService.GetById(id);
            if (result.Result)
            {
                return Ok(result.List);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserDto dto)
        {
            
            var result = await userProjectService.Create(dto);
            if (result.Result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
            
        }
        [HttpPut]
        public async Task<IActionResult> Edit(UserDto dto)
        {

            var result = await userProjectService.Edit(dto);
            if (result.Result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }


        }


    }
}
