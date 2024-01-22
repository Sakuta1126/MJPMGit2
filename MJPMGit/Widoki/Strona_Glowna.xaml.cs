using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MJPMGit.Widoki;
using MJPMGit.Widoki.Klasy;

namespace MJPMGit.Widoki
{
    /// <summary>
    /// Logika interakcji dla klasy Strona_Glowna.xaml
    /// </summary>
    public partial class Strona_Glowna : Window
    {
        public Strona_Glowna()
        {
            InitializeComponent();
            Odswiez();
        }
        public void Odswiez()
        {
            listaWideo.ItemsSource = App.baza.Pobierz<Wideo>();
        }

        private void Odtworz_Click(object sender, RoutedEventArgs e)
        {
            Wideo wideo = listaWideo.SelectedItem as Wideo;
            if(wideo != null)
            {
                Odtwarzacz strona = new Odtwarzacz(wideo);
                strona.ShowDialog();
                Odswiez();
            }
            else
            {
                MessageBox.Show("Zaznacz element na liście!");
            }
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Dodaj strona = new Dodaj();
            strona.ShowDialog();
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            Wideo wideo = listaWideo.SelectedItem as Wideo;
            if (wideo != null)
            {
                App.baza.Usun(wideo);
                MessageBox.Show("Usunięto "+wideo.Nazwa +"!");
                Odswiez();
            }
            else
            {
                MessageBox.Show("Zaznacz element na liście!");
            }
        }
    }
}
