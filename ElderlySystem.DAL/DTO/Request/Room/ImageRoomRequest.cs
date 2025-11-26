using Microsoft.AspNetCore.Http;

namespace ElderlySystem.DAL.DTO.Request.Room
{
    public class ImageRoomRequest
    {
        public List<IFormFile> Images { get; set; }
    }
}
