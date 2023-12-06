using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mir.Objects.Items
{
    internal class Bow : Item
    {
       public static Bow instance { get; private set; }

        public Bow()
        {
            instance = this;
        }

        public override void OnUse()
        {
            _Player.instance.stateMachine.SetNextState(new BowPreparingState());
        }
    }
}
