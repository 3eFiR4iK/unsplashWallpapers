using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using unsplashWallpapers.Dto;

namespace unsplashWallpapers.Service
{
    internal class WindowsService
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public WindowsService() { }

        public void changeWallpappers(ImageDto image)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                image.RealPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public void cleanDownloadPath(ImageDto excludeImage)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo((string)Properties.Settings.Default["downloadPath"]);

            foreach (FileInfo file in di.GetFiles())
            {
                try { file.Delete(); } catch { }
            }
        }
    }
}
