using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final_PELET_PUJOL
{
    public class Player : Object, IState
    {
        public int current_lap;
        public int nb_jail_turn;
        public Piece piece;
        public IState state;

        public Player(int id, string name) : base(id, name)
        {
            this.current_lap = 0;
            this.nb_jail_turn = 0;
            this.piece = null;
            this.state = new OutJail(this);
        }

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
        public Piece Piece 
        { 
            get { return this.piece; }
            set { this.piece = value; }
        }
        public void Go_In_Jail()
        {
            this.state.Go_In_Jail();
        }
        public void Go_Out_Jail()
        {
            this.state.Go_Out_Jail();
        }
        public void ChangeState(IState state)
        {
            this.state = state;
        }
        public IState State
        { get { return this.state; } }

        public override String ToString()
        {
            return this.name + " has the piece " + this.piece.ToString();
        }

        public void PlayTurn(int score1, int score2, Board board)
        {
            int score = score1 + score2;

            if (this.state is Jail && this.nb_jail_turn<3) //the player is in jail
            {
                if (score1 == score2)
                {
                    ChangeState(new OutJail(this));
                    this.current_lap = this.piece.UpdateSquare(score, board, this.current_lap);
                    this.nb_jail_turn = 0;
                    Console.WriteLine("You get out of Jail !");
                }
                else
                {
                    this.nb_jail_turn += 1;
                    Console.WriteLine("You stay in Jail one more turn");
                }
            }
            else
            {
                if(this.nb_jail_turn==3)
                {
                    ChangeState(new OutJail(this));
                    this.current_lap = this.piece.UpdateSquare(score, board, this.current_lap);
                    this.nb_jail_turn = 0;
                    Console.WriteLine("You move to the square " + Convert.ToString(this.piece.Square.Position + 1));
                }
                else
                {
                    this.current_lap = this.piece.UpdateSquare(score, board, this.current_lap);
                    this.nb_jail_turn = 0;
                    Console.WriteLine("You move to the square " + Convert.ToString(this.piece.Square.Position + 1));
                }
            }

            if (this.piece.Square.Position == 29) //square Go to jail
            {
                ChangeState(new Jail(this));
                this.piece.Square = board.Squares_list[9];
                this.nb_jail_turn += 1;
                Console.WriteLine("You go to Jail");
            }
        }
    }
}
