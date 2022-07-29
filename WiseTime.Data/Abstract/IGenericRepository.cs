using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WiseTime.Data.Abstract
{
    public interface IGenericRepository<TModel, TReturnResult>
    {
        Task<TReturnResult> GetAll();
        Task<TReturnResult> FindByCondition(Expression<Func<TModel, bool>> expression);

        Task<TReturnResult> Remove(TModel model);
        Task<TReturnResult> Create(TModel model);
        Task<TReturnResult> Edit(TModel model);


    }
}
