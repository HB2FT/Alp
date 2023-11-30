using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mir.Objects.Items
{
    public class Sword : Item
    {
        public float damage = 25;

        public Sword()
        {
            index = 1;
        }

        public override void OnUse()
        {

            Debug.Log("Use Sword");
        }
    }

}