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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await commentService.GetAll();
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
        public async Task<IActionResult> GetByPostId(int id)
        {

            var result = await commentService.GetByPostId(id);
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
        public async Task<IActionResult> Create(CommentDto dto)
        {

            var result = await commentService.Create(dto);
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
        public async Task<IActionResult> Edit(CommentDto dto)
        {

            var result = await commentService.Edit(dto);
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

            var result = await commentService.Remove(id);
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
