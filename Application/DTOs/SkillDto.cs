using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SkillDto
    //response DTO
    {
        public int Id { get; set; }
        public string SkillName { get; set; } = string.Empty;
        //proficiency percentage
        public int Proficiency { get; set; }
        //user
        public string UserId { get; set; } = string.Empty;
    }
    public class SkillCreateDto
    {
        public string SkillName { get; set; } = string.Empty;
        //proficiency percentage
        public int Proficiency { get; set; }
    }
    public class SkillUpdateDto
    {
        public string SkillName { get; set; } = string.Empty;
        //proficiency percentage
        public int Proficiency { get; set; }
    }
}
