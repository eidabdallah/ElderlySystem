using ElderlySystem.DAL.Enums;

namespace ElderlySystem.DAL.DTO.Request.Room
{
    public class UpdateRoomRequest
    {
        public RoomType? RoomType { get; set; }
        public int? Capacity { get; set; }
        public float? Price { get; set; }
        public string? Description { get; set; }
    }
}
