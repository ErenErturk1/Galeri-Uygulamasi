using System;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    internal static class Program
    {
        public static string CurrentUserRole { get; set; }
        public static string CurrentUserTC {  get; set; }
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Giris());
        }
    }
}
