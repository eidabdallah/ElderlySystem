using EderlySystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Model
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int Capacity { get; set; }
        public int CurrentCapacity { get; set; } = 0;
        public float Price { get; set; } 
        public string? Description { get; set; }
        public Status Status { get; set; } = Status.Pending;
        public List<RoomImage> RoomImages { get; set; } = new List<RoomImage>();

        //relaion 
        public ICollection<ResidentStay> ResidentStays { get; set; } = new List<ResidentStay>();
    }
}
