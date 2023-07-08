using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicBoolean
{
    private bool value;

    public AtomicBoolean(bool value) { this.value = value; }

    public bool Value
    {
        set
        {
            this.value = value;
        }

        get
        {
            bool valueTemp = value;
            value = false;
            return valueTemp;
        }
    }
}
