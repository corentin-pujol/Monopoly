using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final_PELET_PUJOL
{
    public class Piece : Object 
    {
        public Square square;
        
        public Piece(int id, string n) : base(id, n)
        {
            this.square = new Square(0);
        }

        public Square Square 
        { 
            get { return this.square; } 
            set { this.square = value; } 
        }

        public override String ToString()
        {
            return this.id + " : " + this.name;
        }

        public int UpdateSquare(int score, Board board, int lap)
        {
            int next_position = this.square.Position + score;
            
            if (next_position < 40)
            {
                this.square = board.Squares_list[next_position];
            }
            else
            {
                this.square = board.Squares_list[next_position - 40];
                lap += 1;
            }
            return lap;
        }
    }
}
