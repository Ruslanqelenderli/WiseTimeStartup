using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Business.Abstract.ExamServices;
using WiseTime.Business.Concrete.ReturnResult;
using WiseTime.Business.DTOs.ExamDtos;
using WiseTime.Data.Abstract;
using WiseTime.Entity.Entities;

namespace WiseTime.Business.Concrete.Manager.ExamManagers
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IMapper mapper;
        public QuestionManager(IQuestionRepository questionRepository, IMapper mapper)
        {
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }
        public async Task<BusinessReturnResult<QuestionDto>> Create(QuestionDto model)
        {
            model.CreateDate = DateTime.Now;
            var data = mapper.Map<Question>(model);
            var returnresult = await questionRepository.Create(data);
            var result = mapper.Map<BusinessReturnResult<QuestionDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;


        }

        public async Task<BusinessReturnResult<QuestionDto>> Edit(QuestionDto model)
        {

            var data = mapper.Map<Question>(model);

            var returnresult = await questionRepository.Edit(data);
            var result = mapper.Map<BusinessReturnResult<QuestionDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<QuestionDto>> GetAll()
        {

            var returnresult = await questionRepository.GetAll();
            var result = mapper.Map<BusinessReturnResult<QuestionDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<QuestionDto>> GetByExamTypeId(int id)
        {
            var returnresult = await questionRepository.FindByCondition(x => x.ExamTypeId == id);
            var result = mapper.Map<BusinessReturnResult<QuestionDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }

        public async Task<BusinessReturnResult<QuestionDto>> GetById(int id)
        {
            var returnresult = await questionRepository.FindByCondition(x => x.Id == id);
            var result = mapper.Map<BusinessReturnResult<QuestionDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }



        public async Task<BusinessReturnResult<QuestionDto>> Remove(int id)
        {
            var data = await questionRepository.FindByCondition(x => x.Id == id);
            var returnresult = await questionRepository.Remove(data.List.FirstOrDefault());
            var result = mapper.Map<BusinessReturnResult<QuestionDto>>(returnresult);
            if (returnresult.Result)
            {

                return result;
            }
            return result;
        }
    }
}
