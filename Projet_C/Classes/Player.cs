using Projet_C.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C.Classes
{
    public class Player
    {
        private int idPlayer;
        private int balance;
        private string pseudo;
        private string username;
        private string password;
        private DateTime registrationDate;
        private DateTime dateOfBirthday;
        private int isAdmin; //Changement de bool a int car la base de donné ne possede pas de bool, nous réaliserons la verif directement avec 0 ou 1


        public int IdPlayer
        {
            get { return idPlayer; }
            set { idPlayer = value; }
        }

        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public string Pseudo
        {
            get { return pseudo; }
            set { pseudo = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }

        public DateTime DateOfBirthday
        {
            get { return dateOfBirthday; }
            set { dateOfBirthday = value; }
        }

        public int IsAdmin//modification pour accés DB
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

        public Player(int idPlayer, string pseudo, string username, DateTime registrationDate, DateTime dateOfBirthday)
        {
            IdPlayer = idPlayer;
            balance = 10;
            Pseudo = pseudo;
            Username = username;
            RegistrationDate = registrationDate;
            DateOfBirthday = dateOfBirthday;
            isAdmin = 0;
        }

        public Player()
        {
        }

        public override string ToString()
        {
            return $"Id Player : {idPlayer}, Balance : {balance}, Pseudo : {pseudo}, Username : {username}, Registration Date : {registrationDate}, Date of Birthday : {dateOfBirthday}";
        }

        public static List<Player> GetPlayers()
        {
            PlayerDB dB = new PlayerDB();
            return dB.ReadAll();
        }

       /* public static Player GetPlayer()
        {
            PlayerDB dB = new PlayerDB();
            return dB.ReadPlayer();
        }*/



        public bool Insert()
        {
            PlayerDB db = new PlayerDB();
            return db.Insert(this);
        }
    }
}
