using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttackCollider : MonoBehaviour
{
    public static PlayerAttackCollider instance {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Player Attack Collider in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity collidedEntity = collision.gameObject.GetComponent<Entity>();

        if (collidedEntity != null)
        {
            Tepeg�z tepeg�z = collidedEntity.GetComponent<Tepeg�z>();
            if (tepeg�z != null)
            {
                if (tepeg�z.IsDamagable)
                {
                    tepeg�z.health -= 20;
                    tepeg�z.IsDamaged = true;
                    tepeg�z.IsDamagable = false;

                }
            }
            else
            {
                int Direction;
                if (GetComponentInParent<_Player>().isRight) Direction = 1; else Direction = -1;
                collidedEntity.health -= 20;
                collidedEntity.Rigidbody.AddForce(new Vector2(6 * Direction, 0), ForceMode2D.Impulse);
                collidedEntity.IsDamaged = true;
            }

            Hortlak hortlak = GetComponentInParent<Hortlak>();
            //if (hortlak != null) hortlak.isDamaged = true;

            gameObject.SetActive(false);
        }
    }
}
