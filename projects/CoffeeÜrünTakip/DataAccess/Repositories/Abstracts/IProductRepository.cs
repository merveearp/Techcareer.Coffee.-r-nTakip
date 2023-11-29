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
    List<DetailDto> GetAllProductDetails();
    List<DetailDto>GetDetailsByCategoryId(int  categoryId);
    DetailDto GetProductDetail(Guid id);
}
