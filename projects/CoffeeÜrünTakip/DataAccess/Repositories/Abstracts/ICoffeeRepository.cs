using Core.Persistance.Repositories;
using Model.Dtos.ResponseDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstracts;

public interface ICoffeeRepository : IEntityRepository<Coffee, int>
{
    
}
