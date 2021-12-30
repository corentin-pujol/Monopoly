using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final_PELET_PUJOL
{
    public class Player
    {
        public int id;
        public string name;
        public int current_lap;
        public int nb_jail_turn;
        public Piece piece;

        public Player(int i)
        {
            this.id = i;
            Console.WriteLine("Write the name of Player " + this.id + " =>");
            this.name = Convert.ToString(Console.ReadLine());
            this.current_lap = 0;
            this.nb_jail_turn = 0;
            this.piece = null;
        }

        public int Id { get { return this.id; } }
        public string Name { get { return this.name; } }
        public int Current_lap 
        { 
            get { return this.current_lap; }
            set { this.current_lap = value; }
        }
        public int Nb_jail_turn 
        { 
            get { return this.nb_jail_turn; }
            set { this.nb_jail_turn = value; }
        }
        public Piece Piece { get { return this.piece; } }

        public override String ToString()
        {
            return this.name + ", the player " + this.id + ", has the piece " + this.piece.Id;
        }

        public void PlayTurn(int score1, int score2, Board board)
        {
            int score = score1 + score2;

            if (this.piece.Square.Position == 9 && this.nb_jail_turn < 3) //the player is in jail
            {
                if (score1 == score2)
                {
                    this.current_lap = this.piece.UpdateSquare(score, board, this.current_lap);
                    this.nb_jail_turn = 0;
                }
                else
                {
                    this.nb_jail_turn += 1;
                }
            }
            else 
            {
                this.current_lap = this.piece.UpdateSquare(score, board, this.current_lap);
                this.nb_jail_turn = 0;
            }

            if (this.piece.Square.Position == 29) //square Go to jail
            {
                this.piece.Square = board.Squares_list[9];
            }
        }
    }
}
