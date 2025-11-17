using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.DTO.Response.ElderlySponsor
{
    public class ElderlyInfoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string HealthStatus { get; set; }
        public List<string> Diseases { get; set; } = new List<string>();
    }
}
