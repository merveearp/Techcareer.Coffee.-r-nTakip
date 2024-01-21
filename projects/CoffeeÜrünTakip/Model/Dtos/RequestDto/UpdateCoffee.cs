using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.RequestDto
{
    public record UpdateCoffee(int Id, string Name,string Location)
    {
        public static Coffee ConvertToEntity(UpdateCoffee updateCoffeerequest)
        {
            return new Coffee
            {
                Id = updateCoffeerequest.Id,
                Name = updateCoffeerequest.Name,
                Location = updateCoffeerequest.Location,


            };
        }

    }
}
