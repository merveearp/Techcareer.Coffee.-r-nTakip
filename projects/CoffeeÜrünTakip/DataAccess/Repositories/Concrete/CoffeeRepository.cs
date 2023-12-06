using Core.Persistance.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstracts;
using Model.Dtos.ResponseDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete;

public class CoffeeRepository : EfRepositoryBase<BaseDbContext, Coffee, int>, ICoffeeRepository
{
    public CoffeeRepository(BaseDbContext context) : base(context)
    {
    }
   
    
}
