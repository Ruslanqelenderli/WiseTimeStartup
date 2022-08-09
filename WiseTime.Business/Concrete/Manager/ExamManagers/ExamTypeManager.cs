using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Business.Abstract;
using WiseTime.Business.Concrete.ReturnResult;
using WiseTime.Business.DTOs.ExamDtos;
using WiseTime.Data.Abstract;
using WiseTime.Entity.Entities;

namespace WiseTime.Business.Concrete.Manager.ExamManagers
{
    public class ExamTypeManager : IExamTypeService
    {
        private readonly IExamTypeRepository examTypeRepository;
        private readonly IMapper mapper;
        public ExamTypeManager(IExamTypeRepository examTypeRepository, IMapper mapper)
        {
            this.examTypeRepository = examTypeRepository;
            this.mapper = mapper;
        }
        public async Task<BusinessReturnResult<ExamTypeDto>> Create(ExamTypeDto model)
        {
            var data = mapper.Map<ExamType>(model);
            var returnresult = await examTypeRepository.Create(data);
            var result = mapper.Map<BusinessReturnResult<ExamTypeDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;


        }

        public async Task<BusinessReturnResult<ExamTypeDto>> Edit(ExamTypeDto model)
        {

            var data = mapper.Map<ExamType>(model);

            var returnresult = await examTypeRepository.Edit(data);
            var result = mapper.Map<BusinessReturnResult<ExamTypeDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<ExamTypeDto>> GetAll()
        {

            var returnresult = await examTypeRepository.GetAll();
            var result = mapper.Map<BusinessReturnResult<ExamTypeDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<ExamTypeDto>> GetById(int id)
        {
            var returnresult = await examTypeRepository.FindByCondition(x => x.Id == id);
            var result = mapper.Map<BusinessReturnResult<ExamTypeDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }



        public async Task<BusinessReturnResult<ExamTypeDto>> Remove(int id)
        {
            var data = await examTypeRepository.FindByCondition(x => x.Id == id);
            var returnresult = await examTypeRepository.Remove(data.List.FirstOrDefault());
            var result = mapper.Map<BusinessReturnResult<ExamTypeDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }
    }
}
