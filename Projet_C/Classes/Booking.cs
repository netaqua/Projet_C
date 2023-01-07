using Projet_C.Classes;
using Projet_C.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C.Classes
{
    internal class Booking
    {
        private int idBooking;
        private DateTime bookingDate;
        private Player player;
        private VideoGame videoGame;

        public int IdBooking
        {
            get { return idBooking; }
            set { idBooking = value; }
        }

        public DateTime BookingDate
        {
            get { return bookingDate; }
            set { bookingDate = value; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public VideoGame VideoGame
        {
            get { return videoGame; }
            set { videoGame = value; }
        }

        public Booking(int idBooking, DateTime bookingDate, Player player, VideoGame videoGame)
        {
            IdBooking = idBooking;
            BookingDate = bookingDate;
            Player = player;
            VideoGame = videoGame;
        }

        public Booking()
        {

        }

        public override string ToString()
        {
            return $"Id Booking : {idBooking}, Booking Date : {bookingDate},Player : {player}, VideoGame : {videoGame}";
        }
        public static List<Booking> GetBookings()
        {
            BookingDB dB = new BookingDB();
            return dB.ReadAll();
        }

    }
}
