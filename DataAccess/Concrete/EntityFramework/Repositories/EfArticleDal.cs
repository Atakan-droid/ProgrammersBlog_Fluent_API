using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfArticleDal : EfEntityRepositoryBase<Article>, IArticleDal
    {
        public EfArticleDal(DbContext context) : base(context)
        {

        }
    }
}
