using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Business.Abstract;
using WiseTime.Business.Concrete.ReturnResult;
using WiseTime.Business.DTOs;
using WiseTime.Data.Abstract;
using WiseTime.Entity.Entities;

namespace WiseTime.Business.Concrete.Manager
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;
        public CommentManager(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }
        public async Task<BusinessReturnResult<CommentDto>> Create(CommentDto model)
        {
            var data = mapper.Map<Comment>(model);
            var returnresult = await commentRepository.Create(data);
            var result = mapper.Map<BusinessReturnResult<CommentDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<CommentDto>> Edit(CommentDto model)
        {
            var data = mapper.Map<Comment>(model);
            var returnresult = await commentRepository.Edit(data);
            var result = mapper.Map<BusinessReturnResult<CommentDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<CommentDto>> GetAll()
        {
            var returnresult = await commentRepository.GetAll();
            var result = mapper.Map<BusinessReturnResult<CommentDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<CommentDto>> GetById(int id)
        {
            var returnresult = await commentRepository.FindByCondition(x=>x.Id==id);
            var result = mapper.Map<BusinessReturnResult<CommentDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<CommentDto>> GetByPostId(int id)
        {
            var returnresult = await commentRepository.FindByCondition(x => x.PostId == id);
            var result = mapper.Map<BusinessReturnResult<CommentDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<CommentDto>> Remove(int id)
        {
            var comment = await commentRepository.FindByCondition(x => x.Id == id);
            var returnresult = await commentRepository.Remove(comment.List.FirstOrDefault());
            var result = mapper.Map<BusinessReturnResult<CommentDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        
    }
}
