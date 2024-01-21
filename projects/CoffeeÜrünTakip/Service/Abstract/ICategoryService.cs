using Core.Shared;
using Model.Dtos.RequestDto;
using Model.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract;

public interface ICategoryService
{
    Response<CategoryDto> Add(AddCategory addCategoryRequest);
    Response<CategoryDto> Update(UpdateCategory updateCategoryRequest);
    Response<CategoryDto> Delete(int id);
    Response<CategoryDto> GetById(int id);


    Response<List<CategoryDto>> GetAll();
}
