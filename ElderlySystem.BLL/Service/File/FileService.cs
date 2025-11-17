using CloudinaryDotNet;
using ElderlySystem.BLL.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.BLL.Services.File
{
    public class FileService : IFileService
    {
        private readonly Cloudinary _cloudinary;
        private readonly CloudinarySettings _settings;
        public FileService(Cloudinary cloudinary, IOptions<CloudinarySettings> options)
        {
            _cloudinary = cloudinary;
            _settings = options.Value;
        }
        public async Task<bool> DeleteAsync(string publicId)
        {
            if (string.IsNullOrWhiteSpace(publicId))
                return false;
            var deletionParams = new CloudinaryDotNet.Actions.DeletionParams(publicId);
            try
            {
                var res = await _cloudinary.DestroyAsync(deletionParams);
                return res.Result == "ok" || res.Result == "not found";
            }
            catch
            {
                return false;
            }
        }


        public async Task<(string Url, string PublicId)> UploadAsync(IFormFile file, string? folderName = null)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is null or empty");

            var baseFolder = _settings.Folder?.Trim('/');
            var targetFolder = string.IsNullOrWhiteSpace(folderName)
                ? baseFolder
                : string.IsNullOrWhiteSpace(baseFolder) ? folderName!.Trim('/') : $"{baseFolder}/{folderName!.Trim('/')}";

            await using var stream = file.OpenReadStream();

            var uploadParams = new CloudinaryDotNet.Actions.ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = targetFolder,
                UseFilename = false,
                UniqueFilename = true,
                Overwrite = false
            };

            var result = await _cloudinary.UploadAsync(uploadParams);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception($"Cloudinary upload failed: {result.Error?.Message}");

            return (result.SecureUrl!.ToString(), result.PublicId!);
        }
    }
}
