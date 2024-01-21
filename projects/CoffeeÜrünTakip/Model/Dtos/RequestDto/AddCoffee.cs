using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.RequestDto
{

    public record AddCoffee(string Name, string Location)
    {
        public static Coffee ConvertToEntity(AddCoffee addCoffeerequest)
        {
            return new Coffee
            {

                Name = addCoffeerequest.Name,
                Location = addCoffeerequest.Location,

            };
        }
    }
}