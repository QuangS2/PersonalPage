using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProjectDto
    {
        //user id, title, description, project url, demo url

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProjectUrl { get; set; } = string.Empty;
        public string DemoUrl { get; set; } = string.Empty;
        //user id
        public string UserId { get; set; } = string.Empty;
    }
    //create dto
    public class ProjectCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProjectUrl { get; set; } = string.Empty;
        public string DemoUrl { get; set; } = string.Empty;
    }
    public class ProjectUpdateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProjectUrl { get; set; } = string.Empty;
        public string DemoUrl { get; set; } = string.Empty;
    }
}
