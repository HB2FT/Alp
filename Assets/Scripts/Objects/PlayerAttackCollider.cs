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
    }
}
