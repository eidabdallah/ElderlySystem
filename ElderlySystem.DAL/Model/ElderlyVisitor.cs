using Microsoft.EntityFrameworkCore;

namespace ElderlySystem.DAL.Model
{
    [PrimaryKey(nameof(ElderlyId), nameof(VisitorId))]
    public class ElderlyVisitor
    {
        public int ElderlyId { get; set; }
        public Elderly Elderly { get; set; }
        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}
