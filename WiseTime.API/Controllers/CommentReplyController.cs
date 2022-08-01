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
    public class CommentReplyController : ControllerBase
    {
        private readonly ICommentReplyService commentReplyService;
        public CommentReplyController(ICommentReplyService commentReplyService)
        {
            this.commentReplyService = commentReplyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await commentReplyService.GetAll();
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
        public async Task<IActionResult> GetByCommentId(int id)
        {

            var result = await commentReplyService.GetByCommentId(id);
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
        public async Task<IActionResult> Create(CommentReplyDto dto)
        {

            var result = await commentReplyService.Create(dto);
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
        public async Task<IActionResult> Edit(CommentReplyDto dto)
        {

            var result = await commentReplyService.Edit(dto);
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

            var result = await commentReplyService.Remove(id);
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
