using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Data.Abstract;
using WiseTime.Data.Concrete.EntityFramework.Context;
using WiseTime.Data.Concrete.EntityFramework.ReturnResult;

namespace WiseTime.Data.Concrete.EntityFramework.Repository
{
    public class GenericRepository<TModel, TReturnResult, TContext> : IGenericRepository<TModel, TReturnResult>
        where TModel : class
        where TReturnResult:GetAllReturnResult<TModel>,new()
        where TContext : DbContext, new()
    {
        public async Task<TReturnResult> Create(TModel model)
        {
            var result = new TReturnResult();
            try
            {


                using (var tcontext = new TContext())
                {
                    await tcontext.Set<TModel>().AddAsync(model);
                    await tcontext.SaveChangesAsync();

                    result.MainMethod(null, true, "Succeed");
                }
                return result;

            }
            catch (Exception ex)
            {

                result.MainMethod(null, false, ex.Message);
                return result;
            }
        }

        public async Task<TReturnResult> Edit(TModel model)
        {
            var result = new TReturnResult();
            try
            {
                

                using (var tcontext = new TContext())
                {
                    tcontext.Set<TModel>().Update(model);
                    await tcontext.SaveChangesAsync();

                    result.MainMethod(null, true, "Succeed");
                }
                return result;

            }
            catch (Exception ex)
            {

                result.MainMethod(null, false, ex.Message);
                return result;
            }
        }

        public async Task<TReturnResult> FindByCondition(Expression<Func<TModel, bool>> expression)
        {
            var result = new TReturnResult();
            try
            {


                using (var tcontext = new TContext())
                {
                    var list=await tcontext.Set<TModel>().Where(expression).ToListAsync();
                    

                    result.MainMethod(list, true, "Succeed");
                }
                return result;

            }
            catch (Exception ex)
            {

                result.MainMethod(null, false, ex.Message);
                return result;
            }
        }

        public async Task<TReturnResult> GetAll()
        {
            var result = new TReturnResult();
            try
            {


                using (var tcontext = new TContext())
                {
                    var list = await tcontext.Set<TModel>().ToListAsync();


                    result.MainMethod(list, true, "Succeed");
                }
                return result;

            }
            catch (Exception ex)
            {

                result.MainMethod(null, false, ex.Message);
                return result;
            }
        }

        public async Task<TReturnResult> Remove(TModel model)
        {
            var result = new TReturnResult();
            try
            {


                using (var tcontext = new TContext())
                {
                    tcontext.Set<TModel>().Remove(model);
                    await tcontext.SaveChangesAsync();


                    result.MainMethod(null, true, "Succeed");
                }
                return result;

            }
            catch (Exception ex)
            {

                result.MainMethod(null, false, ex.Message);
                return result;
            }
        }

       
    }
}
