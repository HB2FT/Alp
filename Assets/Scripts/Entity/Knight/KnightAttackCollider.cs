using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttackCollider : MonoBehaviour
{
    public Knight parent;
    private int Direction = 1;

    private void Start()
    {
        parent = GetComponentInParent<Knight>();
    }

    private void Update()
    {
        if (parent.isRight) Direction = 1; else Direction = -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player collidedEntity = collision.gameObject.GetComponent<Player>();

        if (collidedEntity != null )
        {
            collidedEntity.health -= 15;
            collidedEntity.Rigidbody.AddForce(new Vector2(6 * Direction, 0), ForceMode2D.Impulse);
        }
    }
}
