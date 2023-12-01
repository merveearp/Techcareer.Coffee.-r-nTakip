using DataAccess.Repositories.Concrete;
using Moq;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_UnitTest.Products;

public class ProductTests
{
    private ProductService _service;
    private Mock<ProductRepository> _mockRepository;

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new Mock<ProductRepository>();
        _service = new ProductService(_mockRepository.Object);
    }
    [Test]


}
