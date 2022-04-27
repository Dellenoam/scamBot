using System;
using System.Drawing;
using System.IO;

namespace ConsoleApp3
{
    internal class Base64
    {
        public string ToBase64_Image(string pc_name, string image_name)
        {
            using (Image image = Image.FromFile($"C:\\Users\\{pc_name}\\{image_name}" + "_сжато_на_50.png"))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        public void FromBase64_Image(string base64_string, string pc_name)
        {
            byte[] bytes = Convert.FromBase64String(base64_string);
            File.WriteAllBytes($"C:\\Users\\{pc_name}\\AppData\\Local\\Temp\\image.png", bytes);
        }
    }
}
