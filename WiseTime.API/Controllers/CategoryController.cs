using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.Business.Abstract;
using WiseTime.Business.DTOs;

namespace WiseTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await categoryService.GetAll();
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
        public async Task<IActionResult> Create(CategoryDto dto)
        {

            var result = await categoryService.Create(dto);
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
        public async Task<IActionResult> Edit(CategoryDto dto)
        {

            var result = await categoryService.Edit(dto);
            if (result.Result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }


        }






        [HttpDelete]
        public async Task<IActionResult> Delete(CategoryDto dto)
        {

            var result = await categoryService.Remove(dto);
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
