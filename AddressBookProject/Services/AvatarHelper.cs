using AddressBookProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookProject.Services
{
    public class AvatarHelper
    {
        public static string DecodeImage(AddressRecord record)
        {
            var binary = Convert.ToBase64String(record.ImageData);
            var ext = Path.GetExtension(record.ImagePath);
            string imageDataUrl = $"data:image/{ext};base64,{binary}";
            return imageDataUrl;
        }

        public static byte[] EncodeImage(IFormFile image)
        {
            var ms = new MemoryStream();
            image.CopyTo(ms);
            var output = ms.ToArray();
            ms.Close();
            ms.Dispose();
            return output;
        }
    }
}
