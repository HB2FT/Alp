using Mir.Entity;
using Mir.Entity.PlayerUtilities.BowSystem;

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
