using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final_PELET_PUJOL
{
    public class OutJail : IState
    {
        Player player;
        public OutJail(Player player)
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
            return "Not jailed !";
        }
    }
}
