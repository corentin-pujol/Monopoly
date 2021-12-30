using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final_PELET_PUJOL
{
    public class Board
    {
        //Champ
        List<Square> squares_list;

        //Constructeur
        public Board()
        {
            for (int i = 0; i < 40; i++)
            {
                Square square = new Square(i);
                this.squares_list.Add(square);
            }
        }

        //Propriétés
        public List<Square> Squares_list
        {
            get { return this.squares_list; }
        }

        public override string ToString()
        {
            string my_square_list = "";
            foreach(Square e in this.squares_list)
            {
                my_square_list += e.ToString() + "\n";
            }
            return my_square_list;
        }
    }
}
