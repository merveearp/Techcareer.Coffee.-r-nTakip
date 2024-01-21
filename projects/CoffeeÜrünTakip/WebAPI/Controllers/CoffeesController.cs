using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.RequestDto;
using Service.Abstract;
using Service.Concrete;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoffeesController : ControllerBase
{
    private readonly ICoffeeService _coffeeService;

    public CoffeesController(ICoffeeService coffeeService)
    {
        _coffeeService = coffeeService;
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] AddCoffee addCoffeerequest)
    {
        var result = _coffeeService.Add(addCoffeerequest);

        if (result.StatusCode == System.Net.HttpStatusCode.Created)
        {
            return Created("/", result);
        }
        return BadRequest(result);
    }
    [HttpPut]
    public IActionResult Update([FromBody] UpdateCoffee updateCoffeerequest)
    {
        var result = _coffeeService.Update(updateCoffeerequest);
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        var result = _coffeeService.Delete(id);
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] int id)
    {
        var result = _coffeeService.GetById(id);
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }



    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _coffeeService.GetAll();
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
