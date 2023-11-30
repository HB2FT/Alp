using UnityEngine;

namespace Mir.Objects.Items
{
    public class Hand : Item
    {
        public Hand()
        {
            index = 0;
        }

        public override void OnUse()
        {
            Debug.Log("Use Hand");
        }
    }
}
