using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Business.Concrete.ReturnResult;
using WiseTime.Business.DTOs;

namespace WiseTime.Business.Abstract
{
    public interface ICommentService:IGenericService<CommentDto,BusinessReturnResult<CommentDto>>
    {
        Task<BusinessReturnResult<CommentDto>> GetByPostId(int id);
    }
}
