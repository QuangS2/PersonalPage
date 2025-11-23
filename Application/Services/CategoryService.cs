using Application.DTOs;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        //repository
        private readonly ICategoryRepository _categoryRepository;
        //mapper
        private readonly IMapper _mapper;
        
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        //create category
        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
        {
            //map category
            var category = _mapper.Map<Categories>(categoryCreateDto);
            //create category
            var createdCategory = await _categoryRepository.CreateCategoryAsync(category);
            //map to dto
            var categoryDto = _mapper.Map<CategoryDto>(createdCategory);
            return categoryDto;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            //get category by id
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return false; // Category not found
            }
            //delete category
            await _categoryRepository.DeleteCategoryAsync(category);
            return true;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            //get all categories
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            //map to dto
            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoryDtos;
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            //get category by id
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return null; // Category not found
            }
            //map to dto
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectsByCategoryIdAsync(int categoryId)
        {
            //get projects by category id
            var projects = await _categoryRepository.GetProjectsByCategoryIdAsync(categoryId);
            //map to dto
            var projectDtos = _mapper.Map<IEnumerable<ProjectDto>>(projects);
            return projectDtos;
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryUpdateDto categoryUpdateDto)
        {
            //get category by id
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return false; // Category not found
            }
            //map update
            _mapper.Map(categoryUpdateDto, category);
            //update category
            await _categoryRepository.UpdateCategoryAsync(category);
            return true;


        }
    }
}
