using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categories : BaseEntity
    {
        //category name, description
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //categories have many projects
        public ICollection<Projects> Projects { get; set; } = new List<Projects>();
    }
}
