using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System.Diagnostics;

namespace SimplePaint
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected async void Open_Menu(object sender, RoutedEventArgs eventArgs)
        {
            try
            {
                // open file dialog
                OpenFileDialog openFile = new OpenFileDialog();

                openFile.AllowMultiple = false;
                openFile.Filters.Add(new FileDialogFilter() { Name = "Images", Extensions = { "jpg", "png", "gif" } });

                string[] files = await openFile.ShowAsync((Window)VisualRoot);

                if (files != null && files.Length > 0)
                {
                    var imageControl = this.FindControl<Image>("ImageSrc");

                    if (imageControl != null)
                    {
                        imageControl.Source = new Bitmap(files[0]);
                    }
                }
            }
            catch (System.Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
