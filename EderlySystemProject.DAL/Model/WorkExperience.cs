using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Model
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string? WorkName { get; set; }
        public string? WorkLocation { get; set; }
        public string? JobTitle { get; set; }
        public DateTime? YearsWorked { get; set; }

        // multi value btw emp and Experience
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
