using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Projects : BaseEntity
    {
        // user id, title, description, project url, demo url
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProjectUrl { get; set; } = string.Empty;
        public string DemoUrl { get; set; } = string.Empty;

        //project belong a user 
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = null!;
        //project have many categories
        public ICollection<Categories> Categories { get; set; } = new List<Categories>();
        //project have many technologies
        public ICollection<Technologies> Technologies { get; set; } = new List<Technologies>();
    }
}
