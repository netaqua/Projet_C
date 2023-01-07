using Projet_C.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C.DAO
{
    internal class CopyDB
    {
        private String connectionString;

        public CopyDB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CopyDB"].ConnectionString;
        }
        public bool Create(Copy c)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString)) // Pas oublier l'auto_incrementation dans la base de donnée pour l'ID
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Copy(idCopy, idGame, idPlayer) VALUES({c.IdCopy}, {c.VideoGame.IdGame}, {c.Player.IdPlayer})", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }
        public Copy Read(int idgame, int idplayer)
        {
            Copy c = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Copy WHERE idGame='@IdGame' and idPlayer='@IdPlayer'", connection);

                cmd.Parameters.AddWithValue("IdGame", idgame);
                cmd.Parameters.AddWithValue("IdPlayer", idplayer);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        c = new Copy();
                        c.IdCopy = reader.GetInt32("idCopy");
                        c.Player.IdPlayer = reader.GetInt32("idPlayer");
                        c.VideoGame.IdGame = reader.GetInt32("idGame");
                    }
                }
            }
            return c;
        }

        public bool Udpdate(Copy c)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE dbo.copy SET idGame = {c.VideoGame.IdGame}, idPlayer = {c.Player.IdPlayer} WHERE idCopy = {c.IdCopy}", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }


        public bool Delete(Copy c)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.copy WHERE idCopy={c.IdCopy}", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public List<Copy> ReadAll()
        {
            List<Copy> copys = new List<Copy>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Copy", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Copy c = new Copy();
                        c.IdCopy = reader.GetInt32("idCopy");
                        c.Player.IdPlayer = reader.GetInt32("idPlayer");
                        c.VideoGame.IdGame = reader.GetInt32("idGame");
                        copys.Add(c);
                    }
                }
            }
            return copys;
        }
    }
}
