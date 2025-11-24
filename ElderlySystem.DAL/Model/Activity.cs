using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Model
{
    public class Activity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "اسم النشاط مطلوب")]
        public string ActivityName { get; set; }

        public string? Description { get; set; }
        [Required(ErrorMessage = "موقع النشاط مطلوب.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "تاريخ النشاط مطلوب")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Start time is required.")]

        public TimeSpan StartTime { get; set; }

        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Participant> ActivityOrganizations { get; set; } = new List<Participant>();


    }
}
