using DataAccess.Exceptions;
using DataAccess.Repositories.Abstracts;
using DataAccess.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Rules;

public class ProductRules
{


    private readonly IProductRepository _productRepository;

    public ProductRules(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void ProductIsPresent(Guid id)
    {
        var product = _productRepository.GetById(id);
        if (product is null)
        {
            throw new NotFoundException($"Id si : {id} olan ürün bulunamadı");
        }
    }

}
