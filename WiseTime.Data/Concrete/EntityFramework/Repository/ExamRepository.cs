using Microsoft.EntityFrameworkCore;
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
    public class ExamRepository : GenericRepository<Exam, DataReturnResult<Exam>, WiseTimeDbContext>, IExamRepository
    {
        
        public async Task<DataReturnResult<Exam>> GetAllInclude()
        {
            var result = new DataReturnResult<Exam>();
            try
            {
                using (var db=new WiseTimeDbContext())
                {
                    var list = await db.Exams.Include(x => x.ExamTypes).ThenInclude(x => x.Questions).ToListAsync();
                    result.MainMethod(list,true,"Succeed");
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.MainMethod(null, false, ex.Message);
                return result;

            }
        }
    }
}
