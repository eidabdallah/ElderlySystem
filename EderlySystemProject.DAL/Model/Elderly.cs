using EderlySystem.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElderlySystem.DAL.Model
{
   
    [Index(nameof(NationalId), IsUnique = true)]
    public class Elderly
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [RegularExpression(@"^\d{9}$", ErrorMessage = "يجب ان يكون رقم الهوية مكون من 9 ارقام")]
        public string NationalId { get; set; }
        public string Doctrine { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HealthStatus { get; set; }
        public ICollection<string> Diseases { get; set; } = new List<string>();
        public DateTime BDate { get; set; }
        public string ComprehensiveExamination { get; set; } // url image
        public string NationalIdImage { get; set; } // url image
        public string HealthInsurance { get; set; } // url image
        public string ReasonRegister { get; set; }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - BDate.Year;
                if (BDate.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
        public ICollection<ElderlySponsor> ElderlySponsors { get; set; } = new List<ElderlySponsor>();

        //relaion 1 - m btw elderly and ResidentStay
        public ICollection<ResidentStay> ResidentStays { get; set; } = new List<ResidentStay>();

        public ICollection<ElderlyVisitor> ElderlyVisitors { get; set; } = new List<ElderlyVisitor>();

    }

}
