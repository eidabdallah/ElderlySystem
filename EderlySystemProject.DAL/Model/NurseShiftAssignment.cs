using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Model
{
    public class NurseShiftAssignment
    {
        public int Id { get; set; }

        public string NurseId { get; set; }
        public Nurse Nurse { get; set; }

        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public DateTime Date { get; set; }

    }
}
