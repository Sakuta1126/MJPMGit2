using MJPMGit.Widoki.Klasy;
using NAudio.CoreAudioApi;
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
using System.IO;
using Path = System.IO.Path;
namespace MJPMGit.Widoki
{
    /// <summary>
    /// Logika interakcji dla klasy Odtwarzacz.xaml
    /// </summary>
    public partial class Odtwarzacz : Window
    {
        MMDevice urzadzenie;
        MMDeviceEnumerator wyznacznik;
        Wideo globalnewideo;
        public Odtwarzacz(Wideo wideo)
        {
            InitializeComponent();
            wyznacznik = new MMDeviceEnumerator();
            urzadzenie = wyznacznik.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            globalnewideo = wideo;
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            element_wideo.Source = new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pliki") + "/" + globalnewideo.Link, UriKind.RelativeOrAbsolute);
            element_wideo.LoadedBehavior = MediaState.Manual;
            element_wideo.UnloadedBehavior = MediaState.Manual;
            element_wideo.Play();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            element_wideo.Play();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            element_wideo.Pause();
        }

        private void od_nowa_Click(object sender, RoutedEventArgs e)
        {
            element_wideo.Source=new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Pliki") + "/" + globalnewideo.Link,UriKind.RelativeOrAbsolute   );
            element_wideo.Play();
        }

        private void dzwiek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            urzadzenie.AudioEndpointVolume.MasterVolumeLevelScalar = (float)dzwiek.Value / 100;

        }
    }
}
