using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Öcü")
        {
            Öcü collidedÖcü = collision.gameObject.GetComponent<Öcü>();
            collidedÖcü.health -= Player.Damage;
        }

        if (collision.gameObject.name == "Tepegöz")
        {
            Tepegöz collidedTepegöz = collision.gameObject.GetComponent<Tepegöz>();
            collidedTepegöz.health -= Player.Damage;
        }
    }
}
