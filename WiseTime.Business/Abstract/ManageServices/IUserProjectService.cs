using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Business.Concrete.ReturnResult;
using WiseTime.Business.DTOs;

namespace WiseTime.Business.Abstract
{
    public interface IUserProjectService:IGenericService<UserDto,BusinessReturnResult<UserDto>>
    {
         Task<string> GenerateToken(UserDto dto);
         Task<BusinessReturnResult<UserDto>> GetByEmail(string  email);
    }
}
