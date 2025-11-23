
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        
        //, create,
        Task<Categories> CreateCategoryAsync(Categories categories);
        //update,
        Task<Categories?> UpdateCategoryAsync(Categories categories);
        //delete
        Task<bool> DeleteCategoryAsync(Categories categories);
        //GetCategoryByIdAsync
        Task<Categories?> GetCategoryByIdAsync(int id);
        //GetAllCategoriesAsync
        Task<IEnumerable<Categories>> GetAllCategoriesAsync();
        //GetProjectsByCategoryIdAsync
        Task<IEnumerable<Projects>> GetProjectsByCategoryIdAsync(int categoryId);


    }
}
