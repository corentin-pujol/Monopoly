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
        Dices dices;
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
            this.dices = new Dices();
        }

        public Dices Dices { get { return this.dices; } }

        public void PiecesChoice()
        {
            foreach (Piece p in pieces_list)
            {
                Console.WriteLine(p.ToString());
            }
            List<Piece> pieces_chosen = new List<Piece>();
            foreach (Player p in players_list)
            {
                Console.WriteLine("\n" + p.name + " choose a piece => ");
                int nb = Convert.ToInt32(Console.ReadLine());
                //We check that the piece has not be chosen by another player
                while (pieces_chosen.Contains(pieces_list[nb - 1]) == true)
                {
                    Console.WriteLine("The piece is already chosen\nChoose another one =>");
                    nb = Convert.ToInt32(Console.ReadLine());
                }
                p.Piece = pieces_list[nb - 1];
                pieces_chosen.Add(pieces_list[nb - 1]);
            }
        }

        public void ViewBoard()
        {
            Console.WriteLine("BOARD OF THE MONOPOLY");
            Console.WriteLine(" ---- ---- ---- ---- ---- ---- ---- ---- ---- ----- ---- ");
            Console.WriteLine("| 21 | 22 | 23 | 24 | 25 | 26 | 27 | 28 | 29 | 30  | 31 |");
            Console.WriteLine("|    |    |    |    |    |    |    |    |    |GO TO|    |");
            Console.WriteLine("|    |    |    |    |    |    |    |    |    |JAIL |    |");
            Console.WriteLine(" ---- ---- ---- ---- ---- ---- ---- ---- ---- ----- ---- ");
            Console.WriteLine("| 20 |                                             | 32 |");
            Console.WriteLine("|    |                                             |    |");
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 19 |                                             | 33 |");
            Console.WriteLine("|    |                                             |    |");
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 18 |                                             | 34 |");
            Console.WriteLine("|    |                                             |    |");
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 17 |                                             | 35 |");
            Console.WriteLine("|    |                                             |    |");
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 16 |                                             | 36 |");
            Console.WriteLine("|    |                                             |    |");
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 15 |                                             | 37 |");
            Console.WriteLine("|    |                                             |    |");
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 14 |                                             | 38 |");
            Console.WriteLine("|    |                                             |    |");
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 13 |                                             | 39 |");
            Console.WriteLine("|    |                                             |    |");
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 12 |                                             | 40 |");
            Console.WriteLine("|    |                                             |    |");
            Console.WriteLine(" ---- ---- ---- ---- ---- ---- ---- ---- ---- ----- ---- ");
            Console.WriteLine("| 11 | 10 |  9 |  8 |  7 |  6 |  5 |  4 |  3 |  2  |  1 |");
            Console.WriteLine("|    |JAIL|    |    |    |    |    |    |    |     |    |");
            Console.WriteLine(" ---- ---- ---- ---- ---- ---- ---- ---- ---- ----- ---- ");

            foreach (Player player in this.players_list)
            {
                Console.WriteLine(player.Name + " is on the square " + Convert.ToString(player.Piece.Square.Position + 1) + ", current lap " + player.Current_lap);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("PARAMETERS OF YOUR GAME\n");
            Console.WriteLine("Choose a number of players => ");
            int nb_players = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose a number of laps => ");
            int nb_laps = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nNAMES OF THE PLAYERS\n");
            List<Player> players_list = new List<Player>();
            for (int i = 1; i <= nb_players; i++)
            {
                players_list.Add(new Player(i));
            }

            Monopoly game = new Monopoly(nb_players, nb_laps, players_list);

            Console.WriteLine("\nCHOICE OF THE PIECES\n");
            game.PiecesChoice();

            Console.WriteLine("\nSTART OF THE GAME\n");
            bool game_end = false;
            while (game_end == false)
            {
                for (int i = 0; i < players_list.Count() && game_end == false; i++)
                {
                    game.ViewBoard();
                    Player player = players_list[i];
                    Console.WriteLine("This is the turn of " + player.Name + "\nPress the ENTER key to roll the dices");
                    Console.ReadKey();

                    game.Dices.Throw_dice();
                    Console.WriteLine(game.Dices.ToString());
                    player.PlayTurn(game.Dices.Score1, game.Dices.Score2, game.board);

                    if (player.Current_lap == game.nb_laps)
                    {
                        Console.WriteLine(player.Name + " has won the game !!!");
                        game_end = true;
                    }
                    else
                    {
                        int cpt = 1;
                        while (game.Dices.Score1 == game.Dices.Score2 && cpt < 3 && player.Nb_jail_turn == 0) //if the player make a double, he rolls the dice again
                        {
                            Console.WriteLine("\nThis is the turn of " + player.Name + "\nPress the ENTER key to roll the dices");
                            Console.ReadKey();
                            game.Dices.Throw_dice();
                            Console.WriteLine(game.Dices.ToString());
                            player.PlayTurn(game.Dices.Score1, game.Dices.Score2, game.board);
                            if (game.Dices.Score1 == game.Dices.Score2) cpt++;
                        }
                        if (cpt == 3) //if he made three time a double, he goes to jail
                        {
                            player.Piece.Square = game.board.Squares_list[9];
                            player.Nb_jail_turn += 1;
                            Console.WriteLine("You have made a double for the third time...\nYou go to Jail");
                        }

                        Console.WriteLine("\nPress the ENTER key to go to the next player's turn");
                        Console.ReadKey();
                        Console.Clear();

                    }
                }
            }
            Console.WriteLine("END OF THE GAME");
            Console.ReadKey();
        }
    }
}
