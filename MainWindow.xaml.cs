using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unosquare.FFME;

namespace ms_video_cut
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Unosquare.FFME.Library.FFmpegDirectory = @"C:\tools\ffmpeg\bin";

            // var vlcLibDirectory = new DirectoryInfo(@"C:\Program Files\VideoLAN\VLC");

            // var options = new string[]
            // {
            //     // VLC options can be given here. Please refer to the VLC command line documentation.
            // };

            // // media.SourceProvider.CreatePlayer(vlcLibDirectory, options);
            // // media.SourceProvider.MediaPlayer.Play(new Uri(@"C:\Users\mateu\Videos\Dron\DJI_0147.MP4"));

            media.MouseLeftButtonDown += media_MouseLeftButtonDown;
            this.Loaded += window_OnPageLoad;

        }
        private void window_OnPageLoad(object sender, RoutedEventArgs e)
        {
            //media.Open(new Uri(@"C:\Users\mateu\Videos\Dron\DJI_0193.MP4"));
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            sliderSeek.Minimum = 0;
            // sliderSeek.Maximum = media.
        }

        private void media_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
                this.WindowState = WindowState.Maximized;
        }
    }
}
