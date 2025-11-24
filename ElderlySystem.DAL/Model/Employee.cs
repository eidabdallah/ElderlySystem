using EderlySystem.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace ElderlySystem.DAL.Model
{
    public class Employee : ApplicationUser
    {
        [Required(ErrorMessage = "المسمّى الوظيفي مطلوب.")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "تاريخ التعيين مطلوب.")]
        public DateTime HireDate { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public string? FieldOfStudy { get; set; } 
        public float? YearsOfStudy { get; set; }
        public string? AcademicDegree { get; set; }
        public DateTime? YearDfGraduation { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<string> Skills { get; set; } = new List<string>();
        public ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();

        public ICollection<Donation> Donations { get; set; } = new List<Donation>();
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}

