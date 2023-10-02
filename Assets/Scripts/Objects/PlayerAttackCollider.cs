using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttackCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity collidedEntitiy = collision.gameObject.GetComponent<Entity>();

        if (collidedEntitiy != null)
        {
            Player parent = GetComponentInParent<Player>();
            int direction;

            if (parent.isRight) direction = 1;
            else direction = -1;

            collidedEntitiy.health -= 20;
            collidedEntitiy.GetComponent<Rigidbody2D>().AddForce(new Vector2(5 * direction, 0), ForceMode2D.Impulse);

            Hortlak hortlak = GetComponentInParent<Hortlak>();
            if (hortlak != null) hortlak.isDamaged = true;

            gameObject.SetActive(false);
        }
    }
}
