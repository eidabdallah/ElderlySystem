using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Model
{
    public class Shift
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "رمز الشفت مطلوب.")]
        [RegularExpression(@"^[ABCabc]$", ErrorMessage = "يجب أن يكون رمز الشفت أحد القيم التالية: A أو B أو C.")]
        public char ShiftKey { get; set; }
        [Required(ErrorMessage = "وقت بداية الشفت مطلوب.")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "وقت نهاية الشفت مطلوب.")]
        public TimeSpan EndTime { get; set; }
        public ICollection<NurseShiftAssignment> NurseShiftAssignments { get; set; } = new List<NurseShiftAssignment>();

    }
}
