using EderlySystem.DAL.Enums;
using ElderlySystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Model
{ 
    public class ResidentStay
    {
        public int Id { get; set; }
        public ResidentStayStatus Status { get; set; } = ResidentStayStatus.Active;
        [Required(ErrorMessage = "تاريخ البداية مطلوب.")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }


        //relaion 1 - m btw elderly and ResidentStay
        public int ElderlyId { get; set; }
        public Elderly Elderly { get; set; }

        //relation btw room and ResidentStay
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
