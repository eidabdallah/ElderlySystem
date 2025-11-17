using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Model
{
    public class Nurse : Employee
    {
        public string ImageCertificate { get; set; }
        public ICollection<NurseShiftAssignment> NurseShiftAssignments { get; set; } = new List<NurseShiftAssignment>();
    }
}
