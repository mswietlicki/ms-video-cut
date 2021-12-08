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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gu.Wpf.Media;
using Microsoft.Win32;

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
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = $"Media files|{this.MediaElement.VideoFormats}|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                this.MediaElement.SetCurrentValue(MediaElementWrapper.SourceProperty, new Uri(openFileDialog.FileName));
            }
        }

        private void OnToggleFullScreenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // if (this.WindowStyle == WindowStyle.SingleBorderWindow)
            // {
            //     this.MediaElement.Stretch = Stretch.UniformToFill;
            //     this.WindowStyle = WindowStyle.None;
            //     this.SizeToContent = SizeToContent.Manual;
            //     this.WindowState = WindowState.Maximized;
            // }
            // else
            // {
            //     this.MediaElement.Stretch = Stretch.UniformToFill;
            //     this.WindowStyle = WindowStyle.SingleBorderWindow;
            //     this.SizeToContent = SizeToContent.WidthAndHeight;
            //     this.WindowState = WindowState.Normal;
            // }

            e.Handled = true;
        }

        private void OnEndFullScreenCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.WindowState == WindowState.Maximized && this.WindowStyle == WindowStyle.None;
        }

        private void OnEndFullScreenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // this.MediaElement.Stretch = Stretch.UniformToFill;
            // this.WindowStyle = WindowStyle.SingleBorderWindow;
            // this.SizeToContent = SizeToContent.WidthAndHeight;
            // this.WindowState = WindowState.Normal;
            e.Handled = true;
        }
    }
}
