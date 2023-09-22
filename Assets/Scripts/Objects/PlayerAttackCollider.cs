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

        /*
        if (collision.gameObject.name == "Öcü")
        {
            Öcü collidedÖcü = collision.gameObject.GetComponent<Öcü>();
            collidedÖcü.health -= Player.Damage;
        }

        if (collision.gameObject.name == "Tepegöz") // Tepeg�z -> Head
        {
            TepegözHead head = collision.gameObject.GetComponentInChildren<TepegözHead>();

            if (head != null)
            {
                Tepegöz collidedTepegöz = collision.gameObject.GetComponent<Tepegöz>();
                collidedTepegöz.health -= Player.Damage;
                collidedTepegöz.Animator.SetBool("isDamaged", true);
                collidedTepegöz.Animator.SetBool("isRunning", false);
                collidedTepegöz.Animator.SetBool("isAttacking", false);
                collidedTepegöz.isDamaged = true;
            }
        }
        */
    }
}
