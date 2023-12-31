﻿using Azure.Core;
using Core.Shared;
using DataAccess.Exceptions;
using DataAccess.Repositories.Abstracts;
using DataAccess.Rules;
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
    private readonly ProductRules _productRules;

    public ProductService(IProductRepository productRepository,ProductRules productRules)
    {
        _productRepository = productRepository;
        _productRules = productRules;
 
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
        try
        {
            var product = _productRepository.GetById(id);
            _productRules.ProductIsPresent(id);
            _productRepository.Delete(product);
            var data = ProductDto.ConvertToResponse(product);
            return new Response<ProductDto>()
            {
                Data = data,
                Message = "Ürün Silindi.",
                StatusCode = System.Net.HttpStatusCode.OK
            };

        }
        catch (NotFoundException ex)
        {
            return new Response<ProductDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.NotFound
            };
        }
        
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

    public Response<List<ProductDto>> GetAllDetails()
    {
        var products = _productRepository.GetAll();
        var response = products.Select(x => ProductDto.ConvertToResponse(x)).ToList();
        return new Response<List<ProductDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<ProductDetailDto>> GetAllDetailsByCategoryId(int categoryId)
    {
       
        var details = _productRepository.GetDetailsByCategoryId(categoryId);
        return new Response<List<ProductDetailDto>>()
        {
            Data = details,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<ProductDetailDto>> GetAllDetailsByCoffeeId(int coffeeId)
    {

        var details = _productRepository.GetDetailsByCoffeeId(coffeeId);
        return new Response<List<ProductDetailDto>>()
        {
            Data = details,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
    public Response<ProductDto> GetById(Guid id)
    {
        try
        {
            _productRules.ProductIsPresent(id);
            var product = _productRepository.GetById(id);
            var response = ProductDto.ConvertToResponse(product);
            return new Response<ProductDto>()
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch(NotFoundException ex)
        {
            return new Response<ProductDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.NotFound
            };
        }
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
