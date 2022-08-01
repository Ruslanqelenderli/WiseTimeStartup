using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Business.Concrete.ReturnResult;
using WiseTime.Business.DTOs;
using WiseTime.Entity.Entities;

namespace WiseTime.Business.Abstract
{
    public interface IPostService:IGenericService<PostDto,BusinessReturnResult<PostDto>>
    {
    }
}
