using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Service
{
    public interface ICategoryService
    {
        //get all
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        //get by id
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        //create
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto);
        //update
        Task<bool> UpdateCategoryAsync(int id, CategoryUpdateDto categoryUpdateDto);
        //delete
        Task<bool> DeleteCategoryAsync(int id);
        //get projects by category id
        Task<IEnumerable<ProjectDto>> GetProjectsByCategoryIdAsync(int categoryId);
    }
}
