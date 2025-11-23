using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technologies : BaseEntity
    {
        // technology name, description
        public string TechnologyName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        //technologies have many projects
        public ICollection<Projects> Projects { get; set; } = new List<Projects>();

    }
}
