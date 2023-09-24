using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttackCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Entity collidedEntitiy = collision.gameObject.GetComponent<Entity>();

        if (collidedEntitiy != null)
        {
            collidedEntitiy.health -= 20;
        }
    }
}
