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
        private EfRoleDal efRoleDal;
        private EfUserDal efUserDal;
        public UnitOfWork(ProgrammersBlogContext context)
        {
            _context = context;
        }

        public IArticleDal Articles => efArticleDal ?? new EfArticleDal(_context);

        public ICategoryDal Categories => efCategoryDal ?? new EfCategoryDal(_context);

        public ICommentDal Comments => efCommentDal ?? new EfCommentDal(_context);

        public IRoleDal Roles => efRoleDal ?? new EfRoleDal(_context);

        public IUserDal Users => efUserDal ?? new EfUserDal(_context);

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
