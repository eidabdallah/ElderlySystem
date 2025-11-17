using EderlySystem.DAL.Enums;

namespace ElderlySystem.DAL.Model
{
    public class Employee : ApplicationUser
    {
        public string JobTitle { get; set; }
        public DateTime HireDate { get; set; }
        public EducationLevel? EducationLevel { get; set; }
        public string? FieldOfStudy { get; set; } 
        public float? YearsOfStudy { get; set; }
        public string? AcademicDegree { get; set; }
        public DateTime? YearDfGraduation { get; set; }
        public string? MaritalStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<string>? Skills { get; set; } = new List<string>();
        // multi value btw emp and Experience
        public ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();

        public ICollection<Donation> Donations { get; set; } = new List<Donation>();
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}

