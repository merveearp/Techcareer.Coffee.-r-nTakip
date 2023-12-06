using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.ResponseDto;

public record ProductDto( Guid Id,string Name, string Ingredient, decimal Price, int CategoryId,int CoffeeId)
{

    public static ProductDto ConvertToResponse(Product product)
    {
        return new ProductDto(
            
            Id : product.Id,
            Name : product.Name,
            Ingredient :product.Ingredient,
            Price :product.Price,
            CategoryId :product.CategoryId,
            CoffeeId : product.CoffeeId

            );
    }


}
