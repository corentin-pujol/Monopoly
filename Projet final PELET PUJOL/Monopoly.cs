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
            Board b = Board.GetInstance();
            this.board = b;
            Dices d = Dices.GetInstance();
            this.dices = d;
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
                Console.WriteLine("\n" + p.Name + " choose a piece => ");
                string[] my_piece = {"1", "2", "3", "4", "5", "6", "7", "8"};
                int nb = 0;
                string choice = Console.ReadLine();
                while (my_piece.Contains(choice) == false)
                {
                    Console.WriteLine("The piece doesn't exist...\nChoose another one =>");
                    choice = Console.ReadLine();
                }
                nb = Convert.ToInt32(choice);
                //We check that the piece has not be chosen by another player
                while (pieces_chosen.Contains(pieces_list[nb - 1]) == true)
                {
                    Console.WriteLine("The piece is already chosen\nChoose another one =>");
                    choice = Console.ReadLine();
                    while (my_piece.Contains(choice) == false)
                    {
                        Console.WriteLine("The piece doesn't exist...\nChoose another one =>");
                        choice = Console.ReadLine();
                    }
                    nb = Convert.ToInt32(choice);
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
            string line =     "|    |    |    |    |    |    |    |    |    |JAIL |    |";
            char[] array = line.ToCharArray();
            foreach (Player player_x in this.players_list)
            {
                if (player_x.Piece.Square.Position+1 >= 21 && player_x.Piece.Square.Position+1 <=31)
                {
                    if(player_x.Piece.Square.Position+1 != 30)
                    {
                        array[player_x.Piece.Square.Position+1 - 19 + (player_x.Piece.Square.Position+1 - 21) * 4] = 'X';
                    }
                }
            }
            line = new string(array);
            Console.WriteLine(line);
            Console.WriteLine(" ---- ---- ---- ---- ---- ---- ---- ---- ---- ----- ---- ");
            Console.WriteLine("| 20 |                                             | 32 |");
            line =            "|    |                                             |    |";
            array = line.ToCharArray();
            foreach (Player player_x in this.players_list)
            {
                if (player_x.Piece.Square.Position+1 == 20)
                {
                    array[2] = 'X';
                }
                else
                {
                    if (player_x.Piece.Square.Position+1 == 32)
                    {
                        array[53] = 'X';
                    }
                }
            }
            line = new string(array);
            Console.WriteLine(line);
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 19 |                                             | 33 |");
            line =            "|    |                                             |    |";
            array = line.ToCharArray();
            foreach (Player player_x in this.players_list)
            {
                if (player_x.Piece.Square.Position+1 == 19)
                {
                    array[2] = 'X';
                }
                else
                {
                    if (player_x.Piece.Square.Position+1 == 33)
                    {
                        array[53] = 'X';
                    }
                }
            }
            line = new string(array);
            Console.WriteLine(line);
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 18 |                                             | 34 |");
            line =            "|    |                                             |    |";
            array = line.ToCharArray();
            foreach (Player player_x in this.players_list)
            {
                if (player_x.Piece.Square.Position+1 == 18)
                {
                    array[2] = 'X';
                }
                else
                {
                    if (player_x.Piece.Square.Position+1 == 34)
                    {
                        array[53] = 'X';
                    }
                }
            }
            line = new string(array);
            Console.WriteLine(line);
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 17 |                                             | 35 |");
            line =            "|    |                                             |    |";
            array = line.ToCharArray();
            foreach (Player player_x in this.players_list)
            {
                if (player_x.Piece.Square.Position+1 == 17)
                {
                    array[2] = 'X';
                }
                else
                {
                    if (player_x.Piece.Square.Position+1 == 35)
                    {
                        array[53] = 'X';
                    }
                }
            }
            line = new string(array);
            Console.WriteLine(line);
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 16 |                                             | 36 |");
            line = "|    |                                             |    |";
            array = line.ToCharArray();
            foreach (Player player_x in this.players_list)
            {
                if (player_x.Piece.Square.Position+1 == 16)
                {
                    array[2] = 'X';
                }
                else
                {
                    if (player_x.Piece.Square.Position+1 == 36)
                    {
                        array[53] = 'X';
                    }
                }
            }
            line = new string(array);
            Console.WriteLine(line);
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 15 |                                             | 37 |");
            line = "|    |                                             |    |";
            array = line.ToCharArray();
            foreach (Player player_x in this.players_list)
            {
                if (player_x.Piece.Square.Position+1 == 15)
                {
                    array[2] = 'X';
                }
                else
                {
                    if (player_x.Piece.Square.Position+1 == 37)
                    {
                        array[53] = 'X';
                    }
                }
            }
            line = new string(array);
            Console.WriteLine(line);
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 14 |                                             | 38 |");
            line = "|    |                                             |    |";
            array = line.ToCharArray();
            foreach (Player player_x in this.players_list)
            {
                if (player_x.Piece.Square.Position+1 == 14)
                {
                    array[2] = 'X';
                }
                else
                {
                    if (player_x.Piece.Square.Position+1 == 38)
                    {
                        array[53] = 'X';
                    }
                }
            }
            line = new string(array);
            Console.WriteLine(line);
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 13 |                                             | 39 |");
            line = "|    |                                             |    |";
            array = line.ToCharArray();
            foreach (Player player_x in this.players_list)
            {
                if (player_x.Piece.Square.Position+1 == 13)
                {
                    array[2] = 'X';
                }
                else
                {
                    if (player_x.Piece.Square.Position+1 == 39)
                    {
                        array[53] = 'X';
                    }
                }
            }
            line = new string(array);
            Console.WriteLine(line);
            Console.WriteLine(" ----                                               ---- ");
            Console.WriteLine("| 12 |                                             | 40 |");
            line = "|    |                                             |    |";
            array = line.ToCharArray();
            foreach (Player player_x in this.players_list)
            {
                if (player_x.Piece.Square.Position+1 == 12)
                {
                    array[2] = 'X';
                }
                else
                {
                    if (player_x.Piece.Square.Position+1 == 40)
                    {
                        array[53] = 'X';
                    }
                }
            }
            line = new string(array);
            Console.WriteLine(line);
            Console.WriteLine(" ---- ---- ---- ---- ---- ---- ---- ---- ---- ----- ---- ");
            Console.WriteLine("| 11 | 10 |  9 |  8 |  7 |  6 |  5 |  4 |  3 |  2  |  1 |");
            Console.WriteLine("|    |JAIL|    |    |    |    |    |    |    |     |    |");
            line =            "|    |    |    |    |    |    |    |    |    |     |    |";
            array = line.ToCharArray();
            foreach (Player player_x in this.players_list)
            {
                if (player_x.Piece.Square.Position+1 >= 1 && player_x.Piece.Square.Position+1 <= 11)
                {
                    array[player_x.Piece.Square.Position+1 + 52 - (player_x.Piece.Square.Position)*6] = 'X';
                }
            }
            line = new string(array);
            Console.WriteLine(line);
            Console.WriteLine(" ---- ---- ---- ---- ---- ---- ---- ---- ---- ----- ---- ");

            foreach (Player player in this.players_list)
            {
                if(player.State is Jail)
                {
                    Console.WriteLine(player.Name + " is in jail... There is " + (3 - player.Nb_jail_turn) + " turn yet, before the end of the travel... Try to make a double !");
                }
                else
                {
                    Console.WriteLine(player.Name + " is on the square " + Convert.ToString(player.Piece.Square.Position + 1) + ", current lap " + player.Current_lap
                        
                        );
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("PARAMETERS OF YOUR GAME\n");
            Console.WriteLine("Choose a number of players => ");

            string[] my_player = { "2", "3", "4", "5", "6", "7", "8" };
            int nb_players = 0;
            string choice = Console.ReadLine();
            while (my_player.Contains(choice) == false)
            {
                Console.WriteLine("Number of player invalid, min number is 2 and max number is 8...\nChoose another one =>");
                choice = Console.ReadLine();
            }
            nb_players = Convert.ToInt32(choice);

            Console.WriteLine("Choose a number of laps => ");
            string[] my_laps = { "1", "2", "3", "4", "5", "6", "7", "8" ,"9", "10", "11", "12", "13", "14", "15"};
            int nb_laps = 0;
            choice = Console.ReadLine();
            while (my_laps.Contains(choice) == false)
            {
                Console.WriteLine("Number of laps invalid, max number is 15...\nChoose another one =>");
                choice = Console.ReadLine();
            }
            nb_laps = Convert.ToInt32(choice);

            Console.WriteLine("\nNAMES OF THE PLAYERS\n");
            List<Player> players_list = new List<Player>();
            string name = "";
            for (int i = 1; i <= nb_players; i++)
            {
                Console.WriteLine("Write the name of Player " + i + " =>");
                name = Convert.ToString(Console.ReadLine());
                players_list.Add(new Player(i, name));
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
                    IState state_svg = player.State;
                    Console.WriteLine("Le joueur est : " + state_svg.ToString());
                    player.PlayTurn(game.Dices.Score1, game.Dices.Score2, game.board);

                    if (player.Current_lap == game.nb_laps)
                    {
                        Console.WriteLine(player.Name + " has won the game !!!");
                        game_end = true;
                    }
                    else
                    {
                        int cpt = 1;
                        while (game.Dices.Score1 == game.Dices.Score2 && cpt < 3 && player.Nb_jail_turn == 0 && state_svg is OutJail) //if the player make a double, he rolls the dice again
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
                            player.ChangeState(new Jail(player));
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
