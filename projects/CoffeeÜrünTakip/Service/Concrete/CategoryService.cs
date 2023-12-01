using Azure.Core;
using Core.Shared;
using DataAccess.Exceptions;
using DataAccess.Repositories.Abstracts;
using DataAccess.Repositories.Concrete;
using Model.Dtos.RequestDto;
using Model.Dtos.ResponseDto;
using Model.Entities;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    public Response<CategoryDto> Add(AddCategory request)
    {
        Category category = AddCategory.ConvertToEntity(request);

        _categoryRepository.Add(category);
        var data = CategoryDto.ConvertToResponse(category);
        return new Response<CategoryDto>
        {
            Data = data,
            Message = "Kategori Eklendi",
            StatusCode = System.Net.HttpStatusCode.Created
        };
    }

    public Response<CategoryDto> Delete(int id)
    {
        try 
        {
            Category category = _categoryRepository.GetById(id);

            _categoryRepository.Delete(category);
            var data = CategoryDto.ConvertToResponse(category);
            return new Response<CategoryDto>
            {
                Data = data,
                Message = "Kategori Silindi .",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch(NotFoundException ex)
        {
             return new Response<CategoryDto>()
             {
                 Message = ex.Message,
                 StatusCode = System.Net.HttpStatusCode.NotFound
             };
        } 
     
    }

    public Response<List<CategoryDto>> GetAll()
    {
        var categories = _categoryRepository.GetAll();
        var response = categories.Select(x => CategoryDto.ConvertToResponse(x)).ToList();
        return new Response<List<CategoryDto>>
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<CategoryDto> GetById(int id)
    {
        try
        {
            var category = _categoryRepository.GetById(id);
            var response = CategoryDto.ConvertToResponse(category);
            return new Response<CategoryDto>
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return new Response<CategoryDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.NotFound
            };
       
        }
     
    }

    public Response<CategoryDto> Update(UpdateCategory request)
    {

        Category category = UpdateCategory.ConvertToEntity(request);
        _categoryRepository.Update(category);
        var response = CategoryDto.ConvertToResponse(category);
        return new Response<CategoryDto>()
        {
            Data = response,
            Message = "Kategori Güncellendi. ",
            StatusCode = System.Net.HttpStatusCode.OK

        };
    }
}
