using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgrammersBlogContext _context;
        private EfArticleDal efArticleDal;
        private EfCategoryDal efCategoryDal;
        private EfCommentDal efCommentDal;
        
        public UnitOfWork(ProgrammersBlogContext context)
        {
            _context = context;
        }

        public IArticleDal Articles => efArticleDal ?? new EfArticleDal(_context);

        public ICategoryDal Categories => efCategoryDal ?? new EfCategoryDal(_context);

        public ICommentDal Comments => efCommentDal ?? new EfCommentDal(_context);

        

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
