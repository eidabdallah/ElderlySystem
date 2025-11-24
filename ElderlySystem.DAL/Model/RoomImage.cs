using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Model
{
    public class RoomImage
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الصورة مطلوبة.")]
        public string Url { get; set; }
        [Required(ErrorMessage = "معرف الصورة مطلوب.")]
        public string PublicId { get; set; }
        public int RoomId {  get; set; }
        public Room Room { get; set; }
    }
}
