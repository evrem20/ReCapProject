using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string AddAsycn(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            string newGUID = CreateGuid() + extension;
            var directory = Directory.GetCurrentDirectory() + "\\wwwroot";
            var path = directory + @"\Images";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string imagePath;
            using (FileStream fileStream = File.Create(path + "\\" + newGUID))
            {
                file.CopyToAsync(fileStream);
                imagePath = path + "\\" + newGUID;
                fileStream.Flush();
            }
            return imagePath.Replace("\\", "/");
        }

        public static string Update (IFormFile file, string OldImagePath)
        {
            Delete(OldImagePath);
            return AddAsycn(file);
        }

        public static void Delete(string ImagePath)
        {
            if (File.Exists(ImagePath.Replace("/", "\\")) && Path.GetFileName(ImagePath)!= "default.png")
            {
                File.Delete(ImagePath.Replace("/", "\\"));
            }        
        }
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString("N")+"-"+ DateTime.Now.Month+"-"+DateTime.Now.Day + "-" + DateTime.Now.Year;
        }
    }
}
