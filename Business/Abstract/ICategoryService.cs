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
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAll(); //we used out tag in dataresult so we can use Ilist tec.
        Task<IDataResult<CategoryListDto>> GetAllByNonDeleted();

        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto,string createdByName); //data transfer object
        Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto,string modifiedByName);
        Task<IResult> Delete(int categoryId,string modifiedByName); //isActive =false
        Task<IResult> HardDelete(int categoryId); // delete from database
    }
}
