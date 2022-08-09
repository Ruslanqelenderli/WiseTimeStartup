using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Business.Concrete.ReturnResult;
using WiseTime.Business.DTOs;

namespace WiseTime.Business.Abstract
{
    public interface ICommentReplyService:IGenericService<CommentReplyDto, BusinessReturnResult<CommentReplyDto>>
    {
        Task<BusinessReturnResult<CommentReplyDto>> GetByCommentId(int id);
    }
}
