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

            Tepeg�z tepeg�z = collidedEntity.GetComponent<Tepeg�z>();
            if (tepeg�z != null)
            {
                if (!tepeg�z.IsDamaged && tepeg�z.IsDamagable)
                {
                    tepeg�z.health -= 20;
                    tepeg�z.IsDamaged = true;
                    tepeg�z.IsDamagable = false;

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
