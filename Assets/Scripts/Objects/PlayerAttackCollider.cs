using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttackCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity collidedEntity = collision.gameObject.GetComponent<Entity>();

        if (collidedEntity != null)
        {
            Player parent = GetComponentInParent<Player>();
            int direction;

            if (parent.isRight) direction = 1;
            else direction = -1;

            Tepegöz tepegöz = collidedEntity.GetComponent<Tepegöz>();
            if (tepegöz != null)
            {
                if (!tepegöz.IsDamaged && tepegöz.IsDamagable)
                {
                    tepegöz.health -= 20;
                    tepegöz.IsDamaged = true;
                    tepegöz.IsDamagable = false;

                }
            }
            else
            {
                collidedEntity.health -= 20;
                collidedEntity.IsDamaged = true;
            }

            Hortlak hortlak = GetComponentInParent<Hortlak>();
            //if (hortlak != null) hortlak.isDamaged = true;

            gameObject.SetActive(false);
        }
    }
}
