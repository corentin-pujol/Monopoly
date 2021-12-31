using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final_PELET_PUJOL
{
    public class Piece
    {
        public int id;
        public string name;
        public Square square;
        
        public Piece(int i, string n)
        {
            this.id = i;
            this.square = new Square(0);
            this.name = n;
        }

        public int Id { get { return this.id; } }
        public string Name { get { return this.name; } }
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
