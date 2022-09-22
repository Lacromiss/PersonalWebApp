using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PersonalWebApp.Utilites
{
    public static class ExImageMethods
    {
        public  static bool CheckSize(this IFormFile formFile,int kb)
        {
            if (formFile.Length/1024*1024<kb)return false;
            return true;
        }
        public static bool CheckType(this IFormFile formFile,string pathh)
        {
            if (formFile.ContentType.Contains(pathh))
            {
                return true;
            }
            return false;
        }
        public static async Task<string> SaveFileAsync(this IFormFile formFile,string patgg)
        {
            string Musi = Guid.NewGuid().ToString() + formFile.FileName;
            string Pathh = Path.Combine(patgg, Musi);
            using (FileStream fs = new FileStream(Pathh, FileMode.Create))
            {
                await formFile.CopyToAsync(fs);
            };
            return Musi;
        }
        
    }
}
