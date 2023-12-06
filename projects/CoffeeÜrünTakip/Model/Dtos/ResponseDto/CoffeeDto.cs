using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.ResponseDto;


    public record CoffeeDto(int Id, string Name,string Location)
    {

        public static CoffeeDto ConvertToResponse(Coffee coffee)
        {
            return new CoffeeDto(

                Id: coffee.Id,
                Name: coffee.Name,
                Location: coffee.Location       
                );
        }


    }


