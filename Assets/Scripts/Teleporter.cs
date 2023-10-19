using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.transform.position = new Vector2(-305f, player.transform.position.y);
        }
    }
}
