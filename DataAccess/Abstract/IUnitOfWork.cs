using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IArticleDal Articles { get; } //unitOfWork.Aticles
        ICategoryDal Categories { get; }
        ICommentDal Comments { get; }
        IRoleDal Roles { get; }
        IUserDal Users { get; } //_unitOfWork.Categories.AddAsync();
        // unitOfWork.Categories.AddAsync(category);
        Task<int> SaveAsync();

    }
}
