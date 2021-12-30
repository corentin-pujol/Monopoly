using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final_PELET_PUJOL
{
    public class Monopoly
    {
        int nb_player;
        int nb_laps;
        Dice dice1;
        Dice dice2;
        List<Piece> pieces_list;
        List<Player> players_list;
        Board board;

        public Monopoly(int nb_player, int nb_laps, List<Player> players_list)
        {
            this.nb_player = nb_player;
            this.nb_laps = nb_laps;
            this.players_list = players_list;

            Piece p1 = new Piece(1, "La Voiture");
            Piece p2 = new Piece(2, "Le Chapeau Haut-de-Forme");
            Piece p3 = new Piece(3, "Le Bateau");
            Piece p4 = new Piece(4, "Le Dé à coudre");
            Piece p5 = new Piece(5, "La Chaussure");
            Piece p6 = new Piece(6, "La Brouette");
            Piece p7 = new Piece(7, "Le Chien");
            Piece p8 = new Piece(8, "Le Fer à repasser");

            this.pieces_list = new List<Piece> { p1, p2, p3, p4, p5, p6, p7, p8 };

            this.board = new Board();
            this.dice1 = new Dice();
            this.dice2 = new Dice();

        }

        static void Main(string[] args)
        {

        }
    }
}
