using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final_PELET_PUJOL
{
    public class Jail : IState
    {
        Player player;
        public Jail(Player player)
        {
            this.player = player;
        }
        public void Go_In_Jail()
        {
            //Put player in jail
            this.player.ChangeState(new Jail(this.player));

        }
        public void Go_Out_Jail()
        {
            //Allow player to go out
            this.player.ChangeState(new OutJail(this.player));
        }

        public override String ToString()
        {
            return "Jailed...\nCurrently, you are in Jail for " + this.player.Nb_jail_turn + "turns yet !";
        }
    }
}
