using EderlySystem.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace ElderlySystem.DAL.Model
{
    [PrimaryKey(nameof(ElderlyId), nameof(SponsorId))]
    public class ElderlySponsor
    {
        public int ElderlyId { get; set; }
        public string SponsorId { get; set; }
        public string KinShip {  get; set; }
        public string Degree { get; set; }
        public Elderly Elderly { get; set; }
        public Status status { get; set; } = Status.Inactive;
        public Sponsor Sponsor { get; set; }

    }
}
