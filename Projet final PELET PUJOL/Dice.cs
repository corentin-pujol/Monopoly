using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final_PELET_PUJOL
{
    public class Dice
    {
        //Champ
        int score;

        //Constructeur
        public Dice()
        {
            this.score = 0;
        }

        //Propriétés
        public int Score
        {
            get { return this.score; }
        }

        public override string ToString()
        {
            return "Score du dé : " + this.score;
        }

        //Méthodes
        /// <summary>
        /// Method for throw the dice and update it score
        /// </summary>
        /// <returns></returns>
        public void throw_dice()
        {
            Random r = new Random();
            this.score = r.Next(1, 7);
        }
    }
}
