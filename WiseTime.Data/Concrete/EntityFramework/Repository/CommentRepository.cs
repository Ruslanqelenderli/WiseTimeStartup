using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Data.Abstract;
using WiseTime.Data.Concrete.EntityFramework.Context;
using WiseTime.Data.Concrete.EntityFramework.ReturnResult;
using WiseTime.Entity.Entities;

namespace WiseTime.Data.Concrete.EntityFramework.Repository
{
    public class CommentRepository:GenericRepository<Comment,GetAllReturnResult<Comment>,WiseTimeDbContext>,ICommentRepository
    {
    }
}
