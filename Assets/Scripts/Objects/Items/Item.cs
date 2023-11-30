using UnityEngine;

namespace Mir.Objects.Items
{
    public abstract class Item
    {
        public int index;

        public abstract void OnUse();
    }
}
