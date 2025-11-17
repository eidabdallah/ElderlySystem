using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.BLL.Services.File
{
    public interface IFileService
    {
        Task<(string Url, string PublicId)> UploadAsync(IFormFile file, string? folderName = null);
        Task<bool> DeleteAsync(string publicId);
    }
}
