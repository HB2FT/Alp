using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mir.Objects.Items
{
    public class Sword : Item
    {
        public float damage = 25;

        public static Sword instance { get; private set; }

        public Sword()
        {
            instance = this;
        }

        public event Action onUse;
        public override void OnUse()
        {

            if (onUse != null) onUse();
        }
    }

}