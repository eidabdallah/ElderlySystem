using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Model
{
    public class Nurse : Employee
    {
        [Required(ErrorMessage = "الشهادة مطلوبة.")]
        public string ImageCertificate { get; set; }
        public ICollection<NurseShiftAssignment> NurseShiftAssignments { get; set; } = new List<NurseShiftAssignment>();
    }
}
