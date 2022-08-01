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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<BusinessReturnResult<CategoryDto>> Create(CategoryDto model)
        {
            var data = mapper.Map<Category>(model);
            var returnresult = await categoryRepository.Create(data);
            var result = mapper.Map<BusinessReturnResult<CategoryDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<CategoryDto>> Edit(CategoryDto model)
        {
            var data = mapper.Map<Category>(model);
            var returnresult = await categoryRepository.Edit(data);
            var result = mapper.Map<BusinessReturnResult<CategoryDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<CategoryDto>> GetAll()
        {
            var returnresult = await categoryRepository.GetAll();
            var result = mapper.Map<BusinessReturnResult<CategoryDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<CategoryDto>> GetById(int id)
        {
            var returnresult = await categoryRepository.FindByCondition(x=>x.Id==id);
            var result = mapper.Map<BusinessReturnResult<CategoryDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        

        public async Task<BusinessReturnResult<CategoryDto>> Remove(int id)
        {
            var data = await categoryRepository.FindByCondition(x => x.Id == id);
            var returnresult = await categoryRepository.Remove(data.List.FirstOrDefault());
            var result = mapper.Map<BusinessReturnResult<CategoryDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }
    }
}
