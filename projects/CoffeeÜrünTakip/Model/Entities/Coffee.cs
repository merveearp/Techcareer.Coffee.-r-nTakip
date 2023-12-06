using Core.Persistance.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Coffee : Entity <int>
{
    public string Name { get; set; }   
    public string Location { get; set; } 

    public List<Category> Categories { get; set; }
    public List<Product> Products { get; set; }


}
