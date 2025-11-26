using EderlySystem.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace ElderlySystem.DAL.DTO.Response.ElderlySponsor
{
    public class ElderlyDetailsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public int Age { get; set; }
        public string Doctrine { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HealthStatus { get; set; }
        public DateTime BDate { get; set; }
        public List<string> Diseases { get; set; }
        public string ComprehensiveExamination { get; set; }
        public string NationalIdImage { get; set; }
        public string HealthInsurance { get; set; }
        public List<ElderlySponsorInfoResponse> Sponsors { get; set; }
    }

}
