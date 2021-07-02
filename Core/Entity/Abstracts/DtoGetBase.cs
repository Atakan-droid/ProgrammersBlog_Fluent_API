using Core.Utilities.Results.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Abstracts
{
    public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
    }
}
