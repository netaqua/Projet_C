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
using System.Windows.Shapes;

namespace Projet_C
{
    /// <summary>
    /// Logique d'interaction pour User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User(Player p)
        {
            InitializeComponent();
            pgInfos.Items.Add(p);
            pgInfos.SelectedItems.Add(p);
            
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Window w = new MainWindow();
            w.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Il faut réussir a faire une popup qui nous demandes les infos sur le user a modifier et ensuite juste faire l'appel de la fonction update du db player.
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
           
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

        private void infoPlayer_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}