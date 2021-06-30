using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    // with out tag we can use ILists and IEnumarables
    public interface IDataResult<out T>:IResult
    {
        public T Data { get;}
    }
}
