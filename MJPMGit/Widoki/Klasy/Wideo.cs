using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MJPMGit.Widoki.Klasy
{
    public class Wideo
    {
        [AutoIncrement,PrimaryKey]
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string Link { get; set; }
        public Wideo() { }

        public Wideo(string nazwa, string opis, string link)
        {
            Nazwa = nazwa;
            Opis = opis;
            Link = link;
        }
    }
}
