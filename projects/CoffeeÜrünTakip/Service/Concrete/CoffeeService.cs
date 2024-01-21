using Core.Shared;
using DataAccess.Exceptions;
using DataAccess.Repositories.Abstracts;
using DataAccess.Repositories.Concrete;
using DataAccess.Rules;
using Model.Dtos.RequestDto;
using Model.Dtos.ResponseDto;
using Model.Entities;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete;

public class CoffeeService : ICoffeeService
{
    private readonly ICoffeeRepository _coffeeRepository;



    public CoffeeService(ICoffeeRepository coffeeRepository)
    {
        _coffeeRepository = coffeeRepository;
    }

    public Response<CoffeeDto> Add(AddCoffee addCoffeerequest)
    {
        Coffee coffee = AddCoffee.ConvertToEntity(addCoffeerequest);
        
        _coffeeRepository.Add(coffee);


        var data = CoffeeDto.ConvertToResponse(coffee);
        return new Response<CoffeeDto>()
        {
            Data = data,
            Message = "Kafe Eklendi.",
            StatusCode = System.Net.HttpStatusCode.Created
        };
    }

    public Response<CoffeeDto> Delete(int id)
    {
        Coffee coffee = _coffeeRepository.GetById(id);

        _coffeeRepository.Delete(coffee);
        var data = CoffeeDto.ConvertToResponse(coffee);
        return new Response<CoffeeDto>
        {
            Data = data,
            Message = "Kafe Silindi .",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<CoffeeDto>> GetAll()
    {
        var coffees = _coffeeRepository.GetAll();
        var response = coffees.Select(x => CoffeeDto.ConvertToResponse(x)).ToList();
        return new Response<List<CoffeeDto>>
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<CoffeeDto> GetById(int id)
    {
        var coffee = _coffeeRepository.GetById(id);
        var response = CoffeeDto.ConvertToResponse(coffee);
        return new Response<CoffeeDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<CoffeeDto> Update(UpdateCoffee updateCoffeerequest)
    {
        Coffee coffee = UpdateCoffee.ConvertToEntity(updateCoffeerequest);

        _coffeeRepository.Update(coffee);
        var response = CoffeeDto.ConvertToResponse(coffee);
        return new Response<CoffeeDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
}


