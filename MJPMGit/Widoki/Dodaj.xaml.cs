using MJPMGit.Widoki.Klasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace MJPMGit.Widoki
{
    /// <summary>
    /// Logika interakcji dla klasy Dodaj.xaml
    /// </summary>
    public partial class Dodaj : Window
    {
        string nazwaPliku = "";
        public Dodaj()
        {
            InitializeComponent();
        }

        private void WczytajBTN_Click(object sender, RoutedEventArgs e)
        {
            var okno = new OpenFileDialog();
            DialogResult wynik = okno.ShowDialog();
            if(wynik == System.Windows.Forms.DialogResult.OK)
            {
                string sciezkaDoPliku = okno.FileName;
                nazwaPliku = System.IO.Path.GetFileName(sciezkaDoPliku);
                string sciezkaZasobow = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pliki") + "/"+nazwaPliku;
                System.IO.File.Move(sciezkaDoPliku, sciezkaZasobow);
                wczytajTxt.Content = "Wczytano plik: TAK";
            }
        }

        private void DodajBTN_Click(object sender, RoutedEventArgs e)
        {
            if(App.SprawdzDlugosc(nazwa.Text,1,100) && App.SprawdzDlugosc(opis.Text,1,100) && App.SprawdzDlugosc(nazwaPliku,1,200))
            {
                Wideo wideo = new Wideo(nazwa.Text,opis.Text,nazwaPliku);
                App.baza.Zapisz(wideo);
                System.Windows.MessageBox.Show("Dodano " + wideo.Nazwa + "!");
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Błędne dane!");
            }
        }
    }
}
