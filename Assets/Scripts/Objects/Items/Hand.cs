using UnityEngine;

namespace Mir.Objects.Items
{
    public class Hand : Item
    {
        public static Hand instance {  get; private set; }

        public Hand()
        {
            instance = this;
        }

        public override void OnUse()
        {
            Debug.Log("Use Hand");
        }
    }
}
