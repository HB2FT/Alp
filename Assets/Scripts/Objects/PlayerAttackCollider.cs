using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "�c�")
        {
            �c� collided�c� = collision.gameObject.GetComponent<�c�>();
            collided�c�.health -= Player.Damage;
        }

        if (collision.gameObject.name == "Tepeg�z")
        {
            Tepeg�z collidedTepeg�z = collision.gameObject.GetComponent<Tepeg�z>();
            collidedTepeg�z.health -= Player.Damage;
        }
    }
}
