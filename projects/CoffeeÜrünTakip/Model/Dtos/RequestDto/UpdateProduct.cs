using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.RequestDto
{
    public record UpdateProduct(Guid Id , string Name, string Ingredient, decimal Price, int CategoryId,int CoffeeId)
    {

        public static Product ConvertToEntity(UpdateProduct request)
        {
            return new Product
            {
                Id =request.Id,
                Name = request.Name,
                Ingredient = request.Ingredient,
                Price = request.Price,
                CategoryId = request.CategoryId,
                CoffeeId = request.CoffeeId,


            };
        }
    }
}

