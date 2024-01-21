using Core.Shared;
using Model.Dtos.RequestDto;
using Model.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface ICoffeeService
    {
        Response<CoffeeDto> Add(AddCoffee addCoffeerequest);
        Response<CoffeeDto> Update(UpdateCoffee updateCoffeerequest);
        Response<CoffeeDto> Delete(int id);
        Response<CoffeeDto> GetById(int id);

        Response<List<CoffeeDto>> GetAll();
        
    }
}
