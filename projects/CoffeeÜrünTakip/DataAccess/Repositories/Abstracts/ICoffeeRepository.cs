using Core.Persistance.Repositories;
using Model.Entities;
using Model.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstracts
{
    public interface ICoffeeRepository : IEntityRepository<Coffee, int>
    {
    

    }
}
