using EderlySystem.DAL.Enums;
using System.Text.Json.Serialization;

namespace ElderlySystem.DAL.DTO.Response.User
{
    public class UserInfoResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Role { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status? Status { get; set; }

    }
}
