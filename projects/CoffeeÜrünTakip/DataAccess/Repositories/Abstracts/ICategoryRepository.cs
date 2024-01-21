using Core.Persistance.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstracts
{
    public interface ICategoryRepository : IEntityRepository<Category,int>
    {

    }
}
