using EderlySystem.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElderlySystem.DAL.Model
{
    [PrimaryKey(nameof(ElderlyId), nameof(SponsorId))]
    public class ElderlySponsor
    {
        public int ElderlyId { get; set; }
        public string SponsorId { get; set; }
        [Required(ErrorMessage = "معرّف الكفيل مطلوب.")]
        public string KinShip {  get; set; }
        [Required(ErrorMessage = "درجة القرابة مطلوبة.")]
        public string Degree { get; set; }
        public Elderly Elderly { get; set; }
        public Status status { get; set; } = Status.Pending;
        public Sponsor Sponsor { get; set; }

    }
}
