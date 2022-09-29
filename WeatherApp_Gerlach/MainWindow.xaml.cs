using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WeatherApp_Gerlach.SupportClasses;

namespace WeatherApp_Gerlach
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textboxCity.Focus();
            LogoLabel.Visibility = Visibility.Collapsed;
            textboxCity.Text = "";
            textBlockDesc.Text = "";
            textblockTemp.Text = "";
            image.ImageSource = new BitmapImage(new Uri("..\\..\\Assets\\startup.png", UriKind.RelativeOrAbsolute));    
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            getWeather();
        }       

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_minmize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void textboxCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                getWeather();
            }
        }

        private void getWeather()
        {
            if (Helper.IsAlphabets(textboxCity.Text))
            {
                textblockTemp.Text = Helper.printWeatherData(HttpHelper.doRequest(textboxCity),this).ToString();
                image.ImageSource = Helper.switchImage();

                if (HttpHelper.doRequest(textboxCity) != null)
                {
                    tbBig.Text = Helper.ActualTemp;
                    textBlockDesc.Text = Helper.WeatherDesc;
                }               
            }
            else
            {
                MessageBox.Show("Nur Buchstaben erlaubt", "Fehler");
                //image.ImageSource = new BitmapImage(new Uri("..\\..\\Assets\\startup.png", UriKind.RelativeOrAbsolute));
            }
            textboxCity.Text = "";            
        }

        private void LogoLabel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow reset = new MainWindow();
            reset.Show();
            this.Close();
            
        }
    }
}
