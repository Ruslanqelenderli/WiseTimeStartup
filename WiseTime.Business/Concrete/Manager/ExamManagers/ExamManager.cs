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

namespace WiseTime.Business.Concrete.Manager
{
    public class ExamManager : IExamService
    {
        private readonly IExamRepository examRepository;
        private readonly IMapper mapper;
        public ExamManager(IExamRepository examRepository, IMapper mapper)
        {
            this.examRepository = examRepository;
            this.mapper = mapper;
        }
        public async Task<BusinessReturnResult<ExamDto>> Create(ExamDto model)
        {
            model.CreateDate = DateTime.Now;
            var data = mapper.Map<Exam>(model);
            var returnresult = await examRepository.Create(data);
            var result = mapper.Map<BusinessReturnResult<ExamDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;


        }

        public async Task<BusinessReturnResult<ExamDto>> Edit(ExamDto model)
        {

            var data = mapper.Map<Exam>(model);

            var returnresult = await examRepository.Edit(data);
            var result = mapper.Map<BusinessReturnResult<ExamDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<ExamDto>> GetAll()
        {

            var returnresult = await examRepository.GetAll();
            var result = mapper.Map<BusinessReturnResult<ExamDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<ExamDto>> GetById(int id)
        {
            var returnresult = await examRepository.FindByCondition(x => x.Id == id);
            var result = mapper.Map<BusinessReturnResult<ExamDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }



        public async Task<BusinessReturnResult<ExamDto>> Remove(int id)
        {
            var data = await examRepository.FindByCondition(x => x.Id == id);
            var returnresult = await examRepository.Remove(data.List.FirstOrDefault());
            var result = mapper.Map<BusinessReturnResult<ExamDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }
    }
}
