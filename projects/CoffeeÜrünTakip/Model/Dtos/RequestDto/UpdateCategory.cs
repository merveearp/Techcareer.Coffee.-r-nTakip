using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.RequestDto
{
    public record UpdateCategory(int Id, string Name)
    {
        public static Category ConvertToEntity(UpdateCategory request)
        {
            return new Category
            {

                Name = request.Name,
                Id = request.Id,

            };
        }
    }
}
