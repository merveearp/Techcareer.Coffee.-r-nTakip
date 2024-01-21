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
        public static Category ConvertToEntity(UpdateCategory updateCategoryrequest)
        {
            return new Category
            {

                Name = updateCategoryrequest.Name,
                Id = updateCategoryrequest.Id,

            };
        }
    }
}
