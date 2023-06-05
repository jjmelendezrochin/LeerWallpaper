using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;


namespace LeerKey1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lee la ubicación del Wallpaper y coloca un archivo de texto para que lo lean los otros equipos
            // y lo coloquen como fondo de pantalla
            const string userRoot = @"HKEY_CURRENT_USER\Control Panel\Desktop";
            const string key = "WallPaper";
            //const string keyName = userRoot + "\\" + key;

            string sFondo = (string)Registry.GetValue(userRoot, key, null);

            string path = @"D:\My Drive\otros\fondo.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(sFondo);
                }
            }
            System.Environment.Exit(0);
        }
    }
}
