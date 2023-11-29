using Azure.Core;
using Core.Shared;
using DataAccess.Repositories.Abstracts;
using Model.Dtos.RequestDto;
using Model.Dtos.ResponseDto;
using Model.Entities;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
 
    }

    public Response<ProductDto> Add(AddProduct request)
    {

        Product product = AddProduct.ConvertToEntity(request);

        product.Id = new Guid();
        _productRepository.Add(product);

        var data = ProductDto.ConvertToResponse(product);
        return new Response<ProductDto>()
        {
            Data = data,
            Message = "Ürün Eklendi.",
            StatusCode = System.Net.HttpStatusCode.Created
        };
    }


    public Response<ProductDto> Delete(Guid id)
    {
        var product = _productRepository.GetById(id);
        _productRepository.Delete(product);
        var data = ProductDto.ConvertToResponse(product);
        return new Response<ProductDto>()
        {
            Data = data,
            Message = "Ürün Silindi.",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<ProductDto>> GetAll()
    {
        var products = _productRepository.GetAll();
        var response = products.Select(x => ProductDto.ConvertToResponse(x)).ToList();
        return new Response<List<ProductDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<DetailDto>> GetAllDetails()
    {
        var details = _productRepository.GetAllProductDetails();
        return new Response<List<DetailDto>>()
        {
            Data = details,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<DetailDto>> GetAllDetailsByCategoryId(int categoryId)
    {
        var details = _productRepository.GetDetailsByCategoryId(categoryId);
        return new Response<List<DetailDto>>()
        {
            Data = details,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<ProductDto> GetById(Guid id)
    {
        var product = _productRepository.GetById(id);
        var response = ProductDto.ConvertToResponse(product);
        return new Response<ProductDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<ProductDto> Update(UpdateProduct request)
    {
        Product product = UpdateProduct.ConvertToEntity(request);
        
        _productRepository.Update(product);
        var response = ProductDto.ConvertToResponse(product);
        return new Response<ProductDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
}
