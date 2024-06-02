using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper
{
    public class ServiceImage
    {
        public static string CreateImage(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileSQL = "";
                var allowedExtentions = new[] { ".jpg", ".jpeg", ".png", ".gif", "webp" };
                var fileExtention = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtentions.Contains(fileExtention))
                {
                    return "";
                }
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwrot","Images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    fileSQL = "/Images/" + fileName;
                }
                return fileSQL;
            }
            return "";
        }
    }
}
