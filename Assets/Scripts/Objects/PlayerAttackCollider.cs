using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttackCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "�c�")
        {
            �c� collided�c� = collision.gameObject.GetComponent<�c�>();
            collided�c�.health -= Player.Damage;
        }

        if (collision.gameObject.name == "Tepeg�z") // Tepeg�z -> Head
        {
            Tepeg�zHead head = collision.gameObject.GetComponentInChildren<Tepeg�zHead>();

            if (head != null)
            {
                Tepeg�z collidedTepeg�z = collision.gameObject.GetComponent<Tepeg�z>();
                collidedTepeg�z.health -= Player.Damage;
                collidedTepeg�z.Animator.SetBool("isDamaged", true);
                collidedTepeg�z.Animator.SetBool("isRunning", false);
                collidedTepeg�z.Animator.SetBool("isAttacking", false);
                collidedTepeg�z.isDamaged = true;
            }
        }
    }
}
