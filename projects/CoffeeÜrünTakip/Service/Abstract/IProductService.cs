using Core.Shared;
using Model.Dtos.RequestDto;
using Model.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract;

public interface IProductService
{
    Response<ProductDto> Add(AddProduct request);
    Response<ProductDto> Update(UpdateProduct request);
    Response<ProductDto> Delete(Guid id);
    Response<ProductDto> GetById(Guid id);

    Response<List<ProductDto>> GetAll();
  
    Response<List<ProductDto>> GetAllDetails();
    Response<List<DetailDto>> GetAllDetailsByCategoryId(int categoryId);
}
