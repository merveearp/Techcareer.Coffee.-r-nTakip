using Core.Persistance.Repositories;
using Model.Dtos.ResponseDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstracts;
public interface IProductRepository : IEntityRepository<Product,Guid>
{
    List<ProductDetailDto> GetAllProductDetails();
   
    List<ProductDetailDto>GetDetailsByCategoryId(int  categoryId);
    List<ProductDetailDto> GetDetailsByCoffeeId(int coffeeId);
    ProductDetailDto GetProductDetail(Guid id);
   
    
}
