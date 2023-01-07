using Projet_C.Classes;
using Projet_C.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Projet_C.Classes
{
    internal class Copy
    {
        private int idCopy;
        private Player player;
        private VideoGame videoGame;

        public int IdCopy
        {
            get { return idCopy; }
            set { idCopy = value; }
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

        public Copy(int idCopy, Player player, VideoGame videogame)
        {
            IdCopy = idCopy;
            Player = player;
            VideoGame = videogame;
        }

        public Copy()
        {
        }

        public override string ToString()
        {
            return $"Id Copy : {idCopy}, Player : {player}, VideoGame : {videoGame}";
        }

    }
}
