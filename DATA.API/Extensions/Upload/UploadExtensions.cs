using Data.API.Extensions.ErrorHandler;
using Entity.API.Models.Dto.Upload;
using Microsoft.AspNetCore.Http;

namespace Data.API.Extensions.Upload
{
    public static class UploadExtensions
    {
        public static async Task<UploaDto> UploadExtension(IFormFile file)
        {
            var root = Path.GetFullPath("wwwRoot");
            string fileName;
            if (file is not null)
            {
                var extensions = Path.GetExtension(file.FileName);
               fileName = Guid.NewGuid().ToString() + extensions;

                var combine = Path.Combine(root + "/image/" + fileName);

                using(var stream = new FileStream(combine, FileMode.Create))
                {
                    try
                    {
                        await file.CopyToAsync(stream);
                        await stream.FlushAsync();
                    }catch(FileLoadException ex) 
                    {
                        throw new Exception("Resim Yüklenemedi");
                    }
                }
            }
            else
            {
                throw new BaseException("Resim Seçilmedi");
            }

            var path = "/image/"+ fileName;

            return new UploaDto
            {
                Name = fileName,
                Path = path
            };
        }
    }
}
