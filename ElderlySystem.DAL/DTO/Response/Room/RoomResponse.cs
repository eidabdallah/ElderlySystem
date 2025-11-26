using ElderlySystem.DAL.Enums;
using System.Text.Json.Serialization;

namespace ElderlySystem.DAL.DTO.Response.Room
{
    public class RoomResponse
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        [JsonIgnore]
        public RoomType RoomType { get; set; }
        public int Capacity { get; set; }
        public int CurrentCapacity { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public RoomStatus Status { get; set; }
        public string RoomTypeName => RoomType switch
        {
            RoomType.FirstClass => "درجة أولى",
            RoomType.SecondClass => "درجة ثانية",
            _ => "غير معروف"
        };
        public string StatusName => Status switch
        {
            RoomStatus.Active => "متاحة",
            RoomStatus.InActive => "غير متاحة",
            _ => "غير معروف"
        };
    }

}
