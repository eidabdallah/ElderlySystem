using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Model
{
    public class Activity
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }

        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }

        //multi value btw Participant and Activity
        public ICollection<Participant> ActivityOrganizations { get; set; } = new List<Participant>();


    }
}
