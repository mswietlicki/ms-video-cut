using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Windows.Threading;

namespace ms_video_cut
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            // Unosquare.FFME.Library.FFmpegDirectory = @"C:\ProgramData\chocolatey\bin\";

            // var vlcLibDirectory = new DirectoryInfo(@"C:\Program Files\VideoLAN\VLC");

            // var options = new string[]
            // {
            //     // VLC options can be given here. Please refer to the VLC command line documentation.
            // };

            // // media.SourceProvider.CreatePlayer(vlcLibDirectory, options);
            // // media.SourceProvider.MediaPlayer.Play(new Uri(@"C:\Users\mateu\Videos\Dron\DJI_0147.MP4"));

            media.MediaOpened += media_MediaOpened;
            media.MouseLeftButtonDown += media_MouseLeftButtonDown;
            media.Play();
            this.KeyUp += media_KeyUp;

            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += timer_Tick;
            timer.Start();

        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void media_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    PauseToggle();
                    break;
            }
        }

        private void PauseToggle()
        {
            if (GetMediaState(media) == MediaState.Play)
                media.Pause();
            else
                media.Play();
        }

        private MediaState GetMediaState(MediaElement media)
        {
            var helper = typeof(MediaElement)
                .GetField("_helper", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(media);

            return helper
                ?.GetType()
                ?.GetField("_currentState", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(helper) as MediaState? ?? MediaState.Close;
        }
        
        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            sliderSeek.Minimum = 0;
            sliderSeek.Maximum = media.NaturalDuration.TimeSpan.TotalMilliseconds / 100;
        }

        private void media_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
                this.WindowState = WindowState.Maximized;
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            sliderSeek.Value = media.Position.TotalMilliseconds / 100;
        }
    }
}
