using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.DTO.Request.ElderlySponsor
{
    public class LinkElderlySponsorRequest
    {
        public int ElderlyId { get; set; }
        public string KinShip { get; set; }
        public string Degree { get; set; }
    }
}
