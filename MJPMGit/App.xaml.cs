using MJPMGit.Widoki.Klasy;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace MJPMGit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Baza Baza;
        public static Baza baza
        {
            get
            {
                
                if (Baza == null)
                {
                    Baza = new Baza(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "wideo.db"));
                }
                
                return Baza;
            }
        }
        public static bool SprawdzDlugosc(string teskt, int minimum, int maximum)
        {
            if (teskt.Length >= minimum && teskt.Length <= maximum)
            { return true; }
            else { return false; }
            
            
            
           
           


        }

    }

}
