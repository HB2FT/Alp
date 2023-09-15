using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TepegözHead : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.GetComponentInChildren<PlayerAttackCollider>().gameObject.activeSelf)
        {
            Tepegöz collidedTepegöz = collision.gameObject.GetComponent<Tepegöz>();
            collidedTepegöz.health -= Player.Damage;    
            collidedTepegöz.Animator.SetBool("isDamaged", true);
            collidedTepegöz.Animator.SetBool("isRunning", false);
            collidedTepegöz.Animator.SetBool("isAttacking", false);
            collidedTepegöz.isDamaged = true;

            Debug.Log("Head Shot");
        }

        Debug.Log("head collided: " + collision.gameObject.GetComponentInChildren<PlayerAttackCollider>().gameObject.tag);
        */
    }
}
