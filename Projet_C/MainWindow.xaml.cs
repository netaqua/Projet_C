using Projet_C.Classes;
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

namespace Projet_C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<VideoGame> videoGames = VideoGame.GetGames();
            dgGame.ItemsSource = videoGames;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            this.Content = l;
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            Registration r = new Registration();
            this.Content = r;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
           // string buttonContent = button.Content.ToString(); utilisation du name plutot que du content car nous n'en avions pas defini
            string buttonContent = button.Name.ToString();

            switch (buttonContent)
            {
                case "Playstation":
                    List<VideoGame> playstation = VideoGame.GetGamesByPlaystation();
                    dgGame.ItemsSource = playstation;
                    break;
                case "XBOX":
                    List<VideoGame> xbox = VideoGame.GetGamesByXbox();
                    dgGame.ItemsSource = xbox;
                    break;
                case "NINTENDO":
                    List<VideoGame> nintendo = VideoGame.GetGamesByNintendo();
                    dgGame.ItemsSource = nintendo;
                    break;
            }
        }
    }
}
