using Azure.Core;
using Core.Shared;
using DataAccess.Exceptions;
using DataAccess.Repositories.Abstracts;
using DataAccess.Repositories.Concrete;
using DataAccess.Rules;
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
    private readonly CategoryRules _categoryRules;

    public CategoryService(ICategoryRepository categoryRepository, CategoryRules categoryRules)
    {
        _categoryRepository = categoryRepository;
        _categoryRules = categoryRules;
    }


    public Response<CategoryDto> Add(AddCategory addCategoryrequest)
    {

        try
        {
            Category category = AddCategory.ConvertToEntity(addCategoryrequest);
            _categoryRules.CategoryNameMustBeUnique(category.Name);

            _categoryRepository.Add(category);
            var data = CategoryDto.ConvertToResponse(category);
            return new Response<CategoryDto>
            {
                Data = data,
                Message = "Kategori Eklendi",
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
        catch (NotFoundException ex)
        {
            return new Response<CategoryDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
       
    }

    public Response<CategoryDto> Delete(int id)
    {
        try 
        {
            Category category = _categoryRepository.GetById(id);
            _categoryRules.CategoryIsPresent(id);

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
            _categoryRules.CategoryIsPresent(id);
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

    public Response<CategoryDto> Update(UpdateCategory updateCategoryrequest)
    {
        try
        {
            Category category = UpdateCategory.ConvertToEntity(updateCategoryrequest);
            _categoryRules.CategoryNameMustBeUnique(category.Name);
            _categoryRepository.Update(category);
            var response = CategoryDto.ConvertToResponse(category);
            return new Response<CategoryDto>()
            {
                Data = response,
                Message = "Kategori Güncellendi. ",
                StatusCode = System.Net.HttpStatusCode.OK

            };
        }
        catch (NotFoundException ex)
        {
            return new Response<CategoryDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }     
    }
}
