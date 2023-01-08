using Projet_C.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Logique d'interaction pour Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
    
        public Registration()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Window w = new MainWindow();
            w.Show();
        }

        private void registrationBtn_Click(object sender, RoutedEventArgs e)
        {
            Player p = new Player();
            p.Username = username.Text;
            p.Password = password.Text;
            p.DateOfBirthday = dateOfBirth.DisplayDate;
            p.Pseudo = pseudo.Text;
            p.RegistrationDate = DateTime.Now;
            p.Insert();
            this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));//Impossible de retourner a la page MainWindows une fois fait, mais la création du player est bon 
        }
    }
}
