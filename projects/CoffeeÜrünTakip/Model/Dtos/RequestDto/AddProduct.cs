using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.RequestDto;

public record AddProduct(string Name , string Ingredient ,decimal Price , int CategoryId)
{

    public static Product ConvertToEntity (AddProduct request)
    {
        return new Product
        {
           
            Name = request.Name,
            Ingredient = request.Ingredient,
            Price = request.Price,
            CategoryId = request.CategoryId

        };
    }
}
