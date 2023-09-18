using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todoist.Entities
{
    public class Goal
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public string? Status { get; set; }
        public int CategoryID { get; set; }
    }
}
