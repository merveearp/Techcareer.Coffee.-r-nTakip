using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.ResponseDto;

public class DetailDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Ingredient { get; init; }
    public decimal Price { get; init; }
    public int CategoryId {  get; init; }
    public string CategoryName { get; init; }
}
