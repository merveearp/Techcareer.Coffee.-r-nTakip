using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.ResponseDto;

public record CategoryDto(int Id , string Name)
{
    public static CategoryDto ConvertToResponse(Category category)
    {
        return new CategoryDto(
            Id: category.Id,
            Name: category.Name

            );
    }
}
