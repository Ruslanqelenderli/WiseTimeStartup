using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Data.Concrete.EntityFramework.ReturnResult;
using WiseTime.Entity.Entities;

namespace WiseTime.Data.Abstract
{
    public interface ICommentRepository:IGenericRepository<Comment,DataReturnResult<Comment>>
    {
    }
}
