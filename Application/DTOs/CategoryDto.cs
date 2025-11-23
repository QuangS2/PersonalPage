using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CategoryDto
    {
        //category name, description
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
    //CreateCategoryDto
    public class CategoryCreateDto
    {
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
    public class CategoryUpdateDto 
    {
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
