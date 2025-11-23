using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Skills : BaseEntity
    {
        //user id,skill name,proficiency percentage
        public string SkillName { get; set; } = string.Empty;
        public int ProficiencyPercentage { get; set; }
        //skill belong to a user
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = null!;

    }
}
