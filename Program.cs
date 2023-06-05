using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace LeerKey1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lee la ubicación del Wallpaper y coloca un archivo de texto para que lo lean los otros equipos
            // y lo coloquen como fondo de pantalla
            string path = null;

            const string userRoot = @"HKEY_CURRENT_USER\Control Panel\Desktop";
            const string key = "WallPaper";

            InputLanguage myDefaultLanguage = InputLanguage.DefaultInputLanguage;
            InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;

            string sDef = myDefaultLanguage.Culture.EnglishName;
            string sLen = myCurrentLanguage.Culture.EnglishName;
           
            // Obtiene el fondo actual
            string sFondo = (string)Registry.GetValue(userRoot, key, null);

            if (sDef.Contains("English"))
            {
                path = @"D:\My Drive\otros\fondo.txt";
            }
            else {
                path = @"D:\Mi unidad\otros\fondo.txt";
            }

            // Borra si existe
            if (File.Exists(path))
            {
                File.Delete(path);                
            }

            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(sFondo);
            }

            System.Environment.Exit(0);
        }
    }
}
