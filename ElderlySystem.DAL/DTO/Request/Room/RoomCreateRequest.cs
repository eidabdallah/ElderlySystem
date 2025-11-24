using ElderlySystem.DAL.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.DTO.Request.Room
{
        public class RoomCreateRequest
        {
            [Required]
            public int RoomNumber { get; set; }

            [Required]
            [StringLength(50)]
            public RoomType RoomType { get; set; }

            [Required]
            [Range(1, 20, ErrorMessage = "Capacity must be at least 1.")]
            public int Capacity { get; set; }

            [Required]
            [Range(0, 99999)]
            public float Price { get; set; }
            public string? Description { get; set; }
            public List<IFormFile> Images { get; set; }
        }
}
