using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.ResponseDto;

public class ProductDetailDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Ingredient { get; init; }
    public decimal Price { get; init; }
    public int CategoryId {  get; init; }
    public int CoffeId { get; init; }
    public string CategoryName { get; init; }
    public string CoffeeName { get; init; }
}
