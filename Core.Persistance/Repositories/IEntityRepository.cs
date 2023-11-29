using Core.Persistance.BaseModel;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Repositories;

public interface IEntityRepository<TEntity, TId> where TEntity : Entity<TId>
{
    void Add(TEntity entity);
    TEntity? GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

    TEntity? GetByFilter(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null

        );
    void Delete(TEntity entity);
    void Update(TEntity entity);
    List<TEntity> GetAll(
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);




}

