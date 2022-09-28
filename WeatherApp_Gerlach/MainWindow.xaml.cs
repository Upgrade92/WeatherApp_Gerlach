using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
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
            
            //https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={b6ee3ba5f78bd0c33c1bf67c46c95709}
            //b6ee3ba5f78bd0c33c1bf67c46c95709  API key
     
            textboxCity.Text = "";
            textBlockTest.Text = "";
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
                textblockTemp.Text = Helper.printWeatherData(Helper.doRequest(textboxCity),this).ToString();
                image.ImageSource = Helper.switchImage();

                if (Helper.doRequest(textboxCity) != null)
                {
                    textBlockTest.Text = Helper.ActualTemp;
                }               
            }
            else
            {
                MessageBox.Show("Nur Buchstaben erlaubt", "Fehler");
                //image.ImageSource = new BitmapImage(new Uri("..\\..\\Assets\\startup.png", UriKind.RelativeOrAbsolute));
            }
        }

    }
}
