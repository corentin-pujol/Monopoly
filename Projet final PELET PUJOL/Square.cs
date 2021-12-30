using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final_PELET_PUJOL
{
    public class Square

    {
        //Champ
        int position;
        string name;

        //Constructeur
        public Square(int position)
        {
            this.position = position;
            if(position==0)
            {
                this.name = "Start";
            }
            else
            {
                if(position==9)
                {
                    this.name = "Jail";
                }
                else
                {
                    if(position==29)
                    {
                        this.name = "Go to Jail";
                    }
                    else
                    {
                        this.name = "Basic";
                    }
                }
            }
        }

        //Propriétés
        public int Position
        {
            get { return this.position; }
        }
        public string Name
        {
            get { return this.name; }
        }

        public override string ToString()
        {
            return "Square position : " + this.position + "\n" + "Square name : " + this.name;
        }
    }
}
