using Projet_C.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private String connectionString;

        public Login()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["ProjetDB"].ConnectionString;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Window w = new MainWindow();
            w.Show();
            
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string add_data = "SELECT * FROM dbo.Player where username=@username and password=@password";
                    SqlCommand cmd = new SqlCommand(add_data, connection);

                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@password", password.Text);
                    cmd.ExecuteNonQuery();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());   //Compte si un User est trouvé en db
                    Player p = new Player(); //Il faudrait essayer d'envoyer p vers les autres pages pour ne pas devoir refaire toutes la recherche une fois la page user ouvert
                    username.Text = "";
                    password.Text = "";
                    if(count > 0)   //Si user est trouvé, il passe à la suite et valide l'opération
                    {
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                p.IdPlayer = reader.GetInt32("idPlayer");
                                p.Balance = reader.GetInt32("balance");
                                p.Pseudo = reader.GetString("pseudo");
                                p.Username = reader.GetString("username");
                                p.Password = reader.GetString("password");
                                p.RegistrationDate = reader.GetDateTime("registrationDate");
                                p.DateOfBirthday = reader.GetDateTime("dateOfBirth");
                                p.IsAdmin = reader.GetInt32("isAdmin");
                            }
                        }
                        if (p.IsAdmin == 1)
                        {
                            //Admin a = new Admin();
                            NavigationService.Navigate(new Admin());
                    }
                        else
                        {
                            if(p.IsAdmin == 0)
                            {
                                //User u = new User();   //Le Login est fonctionnel mais la page User ne veut pas s'afficher (exception) 
                                NavigationService.Navigate(new User());//Peut-etre essayer de passer par une fenetre au lieu d'une page ?
                                //this.Content = u;      //Il faudra aussi voir plus tard pour envoyer soit vers User ou Admin en fonction du statut du Player
                            }
                            else    //Si user introuvable (=0), on affiche un message d'erreur
                            {
                                MessageBox.Show("erreur lors du chargement de l'utilisateur ");    //Si mauvaises données rentrées, ce message s'affiche et on reste à la page de Connexion
                            }
                        }

                         
                    }
                    else    //Si user introuvable (=0), on affiche un message d'erreur
                    {
                        MessageBox.Show("Password or Username not correct");    //Si mauvaises données rentrées, ce message s'affiche et on reste à la page de Connexion
                    }
                  
                }
        }
    }
}
