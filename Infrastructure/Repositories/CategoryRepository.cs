using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        //dbcontext
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
        }

        public async Task<Categories> CreateCategoryAsync(Categories categories)
        {
            await _context.Categories.AddAsync(categories);
            await _context.SaveChangesAsync();
            return categories;
        }


        public async Task<bool> DeleteCategoryAsync(Categories categories)
        {
            var existingCategory = await _context.Categories.FindAsync(categories.Id);
            if (existingCategory == null)
            {
                return false;
            }
            _context.Categories.Remove(existingCategory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Categories>> GetAllCategoriesAsync()
        {
            return await Task.FromResult(_context.Categories.ToList());
        }

        public async Task<Categories?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Projects>> GetProjectsByCategoryIdAsync(int categoryId)
        {
            var category = await _context.Categories
                .Include(c => c.Projects)
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null)
            {
                return Enumerable.Empty<Projects>();
            }

            return category.Projects;
        }

        public async Task<Categories?> UpdateCategoryAsync(Categories categories)
        {
            //update, save changes
            _context.Categories.Update(categories);
            await _context.SaveChangesAsync();
            return categories;
        }
    }
}
