using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final_PELET_PUJOL
{
    public class Object
    {
        protected int id;
        protected string name;

        public Object(int id, string name)
        {
            this.id = id;
            this.name = name;

        }
        public string Name
        { get { return this.name; } set { this.name = value; } }
        public int Id
        { get { return this.id; } set { this.id = value; } }
        /// <summary>
        /// Permet d'avoir le détail d'un objet du monopoly
        /// </summary>
        /// <returns>Les détails sous forme d'une chaine de caractères</returns>
        public override string ToString()
        {
            return this.name + " " + this.id;
        }
    }
}
