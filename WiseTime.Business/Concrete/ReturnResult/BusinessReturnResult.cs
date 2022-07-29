using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseTime.Business.Concrete.ReturnResult
{
    public class BusinessReturnResult<T>
    {
        public ICollection<T> List { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }

        public void MainMethod(ICollection<T> list, bool result, string message)
        {
            List = list;
            Result = result;
            Message = message;
        }
    }
}
