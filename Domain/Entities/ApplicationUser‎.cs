using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Users")]
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Bio { get; set; }
        public string? AvatarUrl { get; set; }
        
        public string? LinkedinUrl { get; set; }
        public string? GithubUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        //user have many skills
        public ICollection<Skills> Skills { get; set; } = new List<Skills>();
        //user have many projects
        public ICollection<Projects> Projects { get; set; } = new List<Projects>();

        //user have many TimelineEvents
        public ICollection<TimelineEvents> TimelineEvents { get; set; } = new List<TimelineEvents>();
    }
}
