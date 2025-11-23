using Application.DTOs;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //service
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //get category by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound("Category not found.");
            }
            return Ok(category);
        }
        //get all categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }
        //create category
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto categoryCreateDto)
        {
            var category = await _categoryService.CreateCategoryAsync(categoryCreateDto);
            if (category == null)
            {
                return BadRequest("Category creation failed.");
            }
            return Ok(category);
        }
        //delete category by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result)
            {
                return NotFound("Category not found.");
            }
            return Ok("Category deleted successfully.");
        }

        //update category by id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            
            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, categoryUpdateDto);
            if (!updatedCategory)
            {
                return NotFound("Category not found.");
            }
            return Ok("Category updated successfully.");
        }
    }
}
