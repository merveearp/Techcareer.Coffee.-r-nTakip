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
        public static Coffee ConvertToEntity(AddCoffee request)
        {
            return new Coffee
            {

                Name = request.Name,
                Location = request.Location,

            };
        }
    }
}