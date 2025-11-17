using EderlySystem.DAL.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.DTO.Request.ElderlySponsor
{
    public class ElderlyRegisterRequest
    {
        public string Name { get; set; }
        public string NationalId { get; set; }
        public string Doctrine { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HealthStatus { get; set; }
        public List<string> Diseases { get; set; } = new List<string>();
        public DateTime BDate { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MaritalStatus MaritalStatus { get; set; }
        public IFormFile ComprehensiveExamination { get; set; }
        public IFormFile NationalIdImage { get; set; }
        public IFormFile HealthInsurance { get; set; }
        public string KinShip { get; set; }
        public string Degree { get; set; }
        public string ReasonRegister { get; set; }

    }
}
