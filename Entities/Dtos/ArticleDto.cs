using Core.Entity.Abstracts;
using Core.Utilities.Results.Complex_Types;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ArticleDto:DtoGetBase
    {
        public Article Article { get; set; }
    
    }
}
