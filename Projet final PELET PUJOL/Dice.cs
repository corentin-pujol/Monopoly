using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final_PELET_PUJOL
{
    public class Dices
    {
        //Champ
        int score1;
        int score2;
        private static Dices instance;

        //Constructeur
        private Dices()
        {
            this.score1 = 0;
            this.score2 = 0;
        }

        //Propriétés
        public int Score1
        {
            get { return this.score1; }
        }
        public int Score2
        {
            get { return this.score2; }
        }

        public override string ToString()
        {
            return "Dice 1 : " + this.score1 + "\nDice 2 : " + this.score2;
        }

        public static Dices GetInstance()
        {
            if(instance==null)
            {
                instance = new Dices();
            }
            return instance;
        }

        public void Throw_dice()
        {
            Random r = new Random();
            this.score1 = r.Next(1, 7);
            this.score2 = r.Next(1, 7);
        }
    }
}
