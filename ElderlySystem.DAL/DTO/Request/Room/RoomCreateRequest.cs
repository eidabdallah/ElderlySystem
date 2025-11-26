using ElderlySystem.DAL.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.DTO.Request.Room
{
        public class RoomCreateRequest
        {
            public int RoomNumber { get; set; }
            public RoomType RoomType { get; set; }

            public int Capacity { get; set; }
            public float Price { get; set; }
            public string Description { get; set; }
            public List<IFormFile> Images { get; set; }
        }
}
