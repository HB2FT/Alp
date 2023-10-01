using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HortlakTrigger : MonoBehaviour
{
    public Hortlak hortlak;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            hortlak.isAlive = true;
        }
    }
}
