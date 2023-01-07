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
    internal class BookingDB
    {
        private String connectionString;

        public BookingDB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BookingDB"].ConnectionString;
        }

        public bool Create(Booking b)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Booking(bookingDate, idPlayer, idGame) VALUES('{b.BookingDate}',{b.Player.IdPlayer} ,{b.VideoGame.IdGame})", connection);
                cmd.Parameters.AddWithValue("bookingDate", b);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public Booking Read(String bookingType)
        {
            Booking b = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Booking WHERE idBooking='@idBooking'", connection);

                cmd.Parameters.AddWithValue("name", bookingType);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        b = new Booking();
                        b.BookingDate = reader.GetDateTime("bookingDate");
                        b.Player.IdPlayer = reader.GetInt32("player");
                        b.VideoGame.IdGame = reader.GetInt32("videGame");
                    }
                }
            }
            return b;
        }
        public bool Update(Booking b)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE dbo.Loan SET bookingDate = {b.BookingDate}, idPlayer = {b.Player.IdPlayer}, idGame = {b.VideoGame.IdGame}", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public bool Delete(Booking b)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Loan WHERE idBooking = {b.IdBooking}", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }


        public List<Booking> ReadAll()
        {
            List<Booking> booking = new List<Booking>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Booking", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Booking b = new Booking();
                        b = new Booking();
                        b.BookingDate = reader.GetDateTime("bookingDate");
                        b.Player.IdPlayer = reader.GetInt32("player");
                        b.VideoGame.IdGame = reader.GetInt32("videGame");
                        booking.Add(b);
                    }
                }
            }
            return booking;
        }


    }
}