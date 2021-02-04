using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Lucraft.AutoClicker
{
    internal enum Theme
    {
        Dark = 0,
        Light = 1
    }

    internal static class Themes
    {
        public static Theme CurrentTheme()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return (Theme)(int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1);
            return Theme.Light;
        }
    }
}
