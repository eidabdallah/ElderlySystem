using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Model
{
    public class Shift
    {
        public int Id { get; set; }
        public char ShiftKey { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public ICollection<NurseShiftAssignment> NurseShiftAssignments { get; set; } = new List<NurseShiftAssignment>();

    }
}
