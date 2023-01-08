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
    /// Logique d'interaction pour User.xaml
    /// </summary>
    public partial class User : Page
    {
        public User()
        {
            InitializeComponent();
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Window w = new MainWindow();
            w.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Il faut réussir a faire une popup qui nous demandes les infos sur le user a modifier et ensuite juste faire l'appel de la fonction update du db player.
            //j'arrive pas a l'ajouter, si tu trouve dit moi
        }
    }
}
