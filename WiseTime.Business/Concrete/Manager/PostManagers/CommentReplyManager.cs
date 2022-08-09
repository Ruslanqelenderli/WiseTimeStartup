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
    public class CommentReplyManager : ICommentReplyService
    {
        private readonly ICommentReplyRepository commentReplyRepository;
        private readonly IMapper mapper;
        public CommentReplyManager(ICommentReplyRepository commentReplyRepository, IMapper mapper)
        {
            this.commentReplyRepository = commentReplyRepository;
            this.mapper = mapper;
        }
        public async Task<BusinessReturnResult<CommentReplyDto>> Create(CommentReplyDto model)
        {
            var data = mapper.Map<AnswerComment>(model);
            var returnresult = await commentReplyRepository.Create(data);
            var result = mapper.Map<BusinessReturnResult<CommentReplyDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<CommentReplyDto>> Edit(CommentReplyDto model)
        {
            var data = mapper.Map<AnswerComment>(model);
            var returnresult = await commentReplyRepository.Edit(data);
            var result = mapper.Map<BusinessReturnResult<CommentReplyDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<CommentReplyDto>> GetAll()
        {
            var returnresult = await commentReplyRepository.GetAll();
            var result = mapper.Map<BusinessReturnResult<CommentReplyDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<CommentReplyDto>> GetByCommentId(int id)
        {
            var returnresult = await commentReplyRepository.FindByCondition(x => x.CommentId == id);
            var result = mapper.Map<BusinessReturnResult<CommentReplyDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<CommentReplyDto>> GetById(int id)
        {
            var returnresult = await commentReplyRepository.FindByCondition(x => x.Id == id);
            var result = mapper.Map<BusinessReturnResult<CommentReplyDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        

        public async Task<BusinessReturnResult<CommentReplyDto>> Remove(int id)
        {
            var data = await commentReplyRepository.FindByCondition(x => x.Id == id);
            var returnresult = await commentReplyRepository.Remove(data.List.FirstOrDefault());
            var result = mapper.Map<BusinessReturnResult<CommentReplyDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }
    }
}
