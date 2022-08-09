using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.Business.Abstract;
using WiseTime.Business.DTOs.ExamDtos;

namespace WiseTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamTypeController : ControllerBase
    {
        private readonly IExamTypeService examTypeService;
        public ExamTypeController(IExamTypeService examTypeService)
        {
            this.examTypeService = examTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await examTypeService.GetAll();
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

            var result = await examTypeService.GetById(id);
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
        public async Task<IActionResult> Create(ExamTypeDto dto)
        {

            var result = await examTypeService.Create(dto);
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
        public async Task<IActionResult> Edit(ExamTypeDto dto)
        {

            var result = await examTypeService.Edit(dto);
            if (result.Result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }


        }






        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await examTypeService.Remove(id);
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
