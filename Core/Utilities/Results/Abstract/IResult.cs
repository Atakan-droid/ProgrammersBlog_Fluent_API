using Core.Utilities.Results.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get;} //resultStatus.Success //ResultStatus.Error
        public string Message { get; }
        public Exception Exception { get; }
    }
}
