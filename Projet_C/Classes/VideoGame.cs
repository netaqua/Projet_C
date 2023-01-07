using Projet_C.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C.Classes
{
    internal class VideoGame
    {
        private int idGame;
        private string name;
        private int creditCost;
        private string console;

        public int IdGame
        {
            get { return idGame; }
            set { idGame = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int CreditCost
        {
            get { return creditCost; }
            set { creditCost = value; }
        }

        public string Console
        {
            get { return console; }
            set { console = value; }
        }

        public VideoGame(int idGame, string name, int creditCost, string console)
        {
            IdGame = idGame;
            Name = name;
            CreditCost = creditCost;
            Console = console;
        }

        public VideoGame() { }

        public override string ToString()
        {
            return $"Id Game : {idGame}, Name : {name}, Credit Cost : {creditCost}, Console : {console}";
        }

        public static List<VideoGame> GetGames()
        {
            VideoGameDB dB = new VideoGameDB();
            return dB.ReadAll();
        }

        public static List<VideoGame> GetGamesByPlaystation()
        {
            VideoGameDB dB = new VideoGameDB();
            return dB.SortByPlaystation();
        }
        public static List<VideoGame> GetGamesByXbox()
        {
            VideoGameDB dB = new VideoGameDB();
            return dB.SortByXbox();
        }

        public static List<VideoGame> GetGamesByNintendo()
        {
            VideoGameDB dB = new VideoGameDB();
            return dB.SortByNintendo();
        }

    }
}
