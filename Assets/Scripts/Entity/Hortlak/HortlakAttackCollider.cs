using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HortlakAttackCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        int direction;

        if ((player.transform.position.x - transform.position.x) > 0)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        if (player != null)
        {
            player.health -= 15;
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(5 * direction, 0), ForceMode2D.Impulse);
        }
    }
}
