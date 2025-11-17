using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Model
{
    public class RoomImage
    {
        public int Id { get; set; }

        public string? Description { get; set; }
        public int RoomId {  get; set; }
        public Room Room { get; set; }
    }
}
