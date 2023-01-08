using Projet_C.Classes;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Projet_C.DAO
{
    internal class PlayerDB
    {
        private String connectionString;

        public PlayerDB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ProjetDB"].ConnectionString;
        }

        public Player GetConnection(String playerUsername, String passWord)
        {
            Player p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.player WHERE username='@Username' and password= '@Password", connection);

                cmd.Parameters.AddWithValue("Username", playerUsername);
                cmd.Parameters.AddWithValue("Password", passWord);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        p = new Player();
                        p.IdPlayer = reader.GetInt32("idPlayer");
                        p.Balance = reader.GetInt32("balance");
                        p.Pseudo = reader.GetString("pseudo");
                        p.Username = reader.GetString("username");
                        p.Password = reader.GetString("password");//Il Faut l'ajouter a player pour pouvoir verifier que la connection peut se faire
                        p.RegistrationDate = reader.GetDateTime("registrationDate");
                        p.DateOfBirthday = reader.GetDateTime("dateOfBirth");
                        p.IsAdmin = reader.GetInt32("isAdmin");// Il faut modifier isAdmin pour pouvoir y a vaoir accées depuis ici
                    }
                }
            }
            return p;//Ne pas oublier de verifier si les information sont entré pour une connection, sinon accè bloqué.
        }

        public bool Create(Player p)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString)) // Pas oublier l'auto_incrementation dans la base de donnée pour l'ID
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.player(balance, username, password, registrationDate, dateOfBirth, isAdmin) VALUES({p.Balance}, '{p.Username}', '{p.Password}', {p.RegistrationDate}, {p.DateOfBirthday}, {p.IsAdmin})", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public Player Read(String playerUsername)
        {
            Player p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.player WHERE username='@Username'", connection);

                cmd.Parameters.AddWithValue("Username", playerUsername);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        p = new Player();
                        p.IdPlayer = reader.GetInt32("idPlayer");
                        p.Balance = reader.GetInt32("balance");
                        p.Username = reader.GetString("username");
                        p.Pseudo = reader.GetString("pseudo");
                        p.Password = reader.GetString("password");//Il Faut l'ajouter a player pour pouvoir verifier que la connection peut se faire
                        p.RegistrationDate = reader.GetDateTime("registrationDate");
                        p.DateOfBirthday = reader.GetDateTime("dateOfBirth");
                        p.IsAdmin = reader.GetInt32("isAdmin");// Il faut modifier isAdmin pour pouvoir y a vaoir accées depuis ici
                    }
                }
            }
            return p;
        }

        public bool Udpdate(Player p)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE dbo.player SET balance = {p.Balance}, username = '{p.Username}', password = '{p.Password}', registrationDate = {p.RegistrationDate}, dateOfBirth = {p.DateOfBirthday} WHERE idPlayer = {p.IdPlayer}", connection);
                connection.Open();
                success = cmd.ExecuteNonQuery() > 0;
            }
            return success;
        }

        public bool Delete(Player p)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.player WHERE idPlayer=@id", connection);
                    cmd.Parameters.AddWithValue("id", p.IdPlayer);
                    connection.Open();
                    success = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Une erreur sql s'est produite! " + e.ErrorCode);
            }

            return success;
        }


        public List<Player> ReadAll()
        {
            List<Player> players = new List<Player>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Player", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Player player = new Player();
                        player.IdPlayer = reader.GetInt32("idPlayer");
                        player.Balance = reader.GetInt32("balance");
                        player.Pseudo = reader.GetString("pseudo");
                        player.Username = reader.GetString("username");
                        player.Password = reader.GetString("password");//Il Faut l'ajouter a player pour pouvoir verifier que la connection peut se faire
                        player.RegistrationDate = reader.GetDateTime("registrationDate");
                        player.DateOfBirthday = reader.GetDateTime("dateOfBirth");
                        player.IsAdmin = reader.GetInt32("isAdmin");// Il faut modifier isAdmin pour pouvoir y a vaoir accées depuis ici
                        players.Add(player);
                    }
                }
            }
            return players;
        }
       /* public List<Player> ReadPlayer()       //modifier pour n'avoir que les infos de son Player
        {
            List<Player> players = new List<Player>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Player WHERE username='@Username' and password= '@Password", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Player player = new Player();
                        player.IdPlayer = reader.GetInt32("idPlayer");
                        player.Balance = reader.GetInt32("balance");
                        player.Username = reader.GetString("username");
                        player.Password = reader.GetString("password");//Il Faut l'ajouter a player pour pouvoir verifier que la connection peut se faire
                        player.RegistrationDate = reader.GetDateTime("registrationDate");
                        player.DateOfBirthday = reader.GetDateTime("dateOfBirth");
                        player.IsAdmin = reader.GetInt32("isAdmin");// Il faut modifier isAdmin pour pouvoir y a vaoir accées depuis ici
                        players.Add(player);
                    }
                }
            }
            return players;
        }
       */

        public bool Insert(Player p)
        {
            bool success = false;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT into dbo.Player(username,password,dateOfBirth, registrationDate,pseudo) values ('{p.Username}','{p.Password}','{p.DateOfBirthday}','{p.RegistrationDate}','{p.Pseudo}')",connection);
                connection.Open(); // permet d'excécuter une commande d'insert / update / delete
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }

            return success;
        }
    }
}
