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
    public class PostManager : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;
        public PostManager(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }
        public async Task<BusinessReturnResult<PostDto>> Create(PostDto model)
        {
            model.CreateDate = DateTime.Now;
            var data = mapper.Map<Post>(model);
            var returnresult = await postRepository.Create(data);
            var result = mapper.Map<BusinessReturnResult<PostDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;


        }

        public async Task<BusinessReturnResult<PostDto>> Edit(PostDto model)
        {
            
            var data = mapper.Map<Post>(model);
            var returnresult = await postRepository.Edit(data);
            var result = mapper.Map<BusinessReturnResult<PostDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<PostDto>> GetAll()
        {

            var returnresult = await postRepository.GetAll();
            var result = mapper.Map<BusinessReturnResult<PostDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<PostDto>> GetById(int id)
        {
            var returnresult = await postRepository.FindByCondition(x=>x.Id==id);
            var result = mapper.Map<BusinessReturnResult<PostDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<PostDto>> Remove(PostDto model)
        {
            var data = mapper.Map<Post>(model);
            var returnresult = await postRepository.Remove(data);
            var result = mapper.Map<BusinessReturnResult<PostDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<PostDto>> RemoveById(int id)
        {
            var data = await postRepository.FindByCondition(x => x.Id == id);
            var returnresult = await postRepository.Remove(data.List.FirstOrDefault());
            var result = mapper.Map<BusinessReturnResult<PostDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }
    }
}
