using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.RequestDto
{

    public record AddCategory(string Name)
    {
        public static Category ConvertToEntity(AddCategory addCategoryrequest)
        {
            return new Category
            {

                Name = addCategoryrequest.Name,

            };
        }
    }
}
