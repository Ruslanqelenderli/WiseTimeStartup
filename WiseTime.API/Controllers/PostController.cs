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
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await postService.GetAll();
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

            var result = await postService.GetById(id);
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
        public async Task<IActionResult> Create(PostDto dto)
        {

            var result = await postService.Create(dto);
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
        public async Task<IActionResult> Edit(PostDto dto)
        {

            var result = await postService.Edit(dto);
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

            var result = await postService.RemoveById(id);
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
