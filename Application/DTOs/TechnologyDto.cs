using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TechnologyDto
    {
        //technology name, description
        public string TechnologyName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
    //update dto
    public class TechnologyUpdateDto
    {
        //technology name, description
        public string TechnologyName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
    //create dto
    public class TechnologyCreateDto
    {
        //technology name, description
        public string TechnologyName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
