using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WiseTime.Business.Abstract
{
    public interface IGenericService<TModel,TReturnResult>
    {
        Task<TReturnResult> GetAll();
        Task<TReturnResult> GetById(int id);

        Task<TReturnResult> Remove(int id);
        Task<TReturnResult> Create(TModel model);
        Task<TReturnResult> Edit(TModel model);
    }
}
