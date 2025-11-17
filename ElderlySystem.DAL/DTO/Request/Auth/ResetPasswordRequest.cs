using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.DTO.Request.Auth
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string Code { get; set; }
    }
}
