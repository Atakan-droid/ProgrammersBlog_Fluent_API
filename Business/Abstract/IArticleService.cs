using Core.Utilities.Results.Abstract;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int articleId);
        Task<IDataResult<ArticleListDto>> GetAll(); //we used out tag in dataresult so we can use Ilist tec.
        Task<IDataResult<ArticleListDto>> GetAllByNonDeleted();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);
        Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName); //data transfer object
        Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName);
        Task<IResult> Delete(int articleId, string modifiedByName); //isActive =false
        Task<IResult> HardDelete(int articleId); // delete from database
    }
}
