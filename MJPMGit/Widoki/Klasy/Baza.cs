using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MJPMGit.Widoki.Klasy
{
    public class Baza
    {
        private readonly SQLiteConnection baza;
        public Baza(string path)
        {
            baza = new SQLiteConnection(path);
            baza.CreateTable<Wideo>();
        }
            public int Zapisz<T>(T obiekt)
            {
            return baza.Insert(obiekt);
            } 
            public int Usun<T>(T obiekt)
            {
            return baza.Delete(obiekt);
            } 
            public List<T> Pobierz<T>() where T : new()
            {
            return baza.Table<T>().ToList();
            }
    }
}
