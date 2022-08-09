using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Business.Concrete.ReturnResult;
using WiseTime.Business.DTOs.ExamDtos;

namespace WiseTime.Business.Abstract
{
    public interface IExamService:IGenericService<ExamDto,BusinessReturnResult<ExamDto>>
    {
    }
}
