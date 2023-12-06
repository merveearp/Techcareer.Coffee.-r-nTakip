using Core.Persistance.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Product : Entity<Guid>
{
    public string Name { get; set; }
    public string Ingredient { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int CoffeeId { get; set; }
    
    public Category Category { get; set; }

    public Coffee Coffee { get; set; }
         


}
