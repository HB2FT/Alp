using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttackTrigger : MonoBehaviour
{
    public Knight parent;
    public GameObject attackCollider;

    float triggerTime;
    float attackStartOffset;

    int Direction;

    private void Start()
    {
        parent = GetComponentInParent<Knight>();

        triggerTime = 0;
        attackStartOffset = 0.300f;
    }

    private void Update()
    {
        if (parent.isRight) Direction = 1; else Direction = -1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Entity collidedEntity = collision.GetComponent<Entity>();
        Debug.Log("Trigger time" + triggerTime);


        if (collidedEntity != null)
        {
            triggerTime += Time.deltaTime;

            if (triggerTime > attackStartOffset)
            {
                parent.Animator.SetTrigger("Attack");

                if (triggerTime > attackStartOffset + attackStartOffset)
                {
                    collidedEntity.GetComponent<Rigidbody2D>().AddForce(new Vector2(6 * Direction, 0), ForceMode2D.Impulse);

                    triggerTime = 0;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerTime = 0;
    }

    [Obsolete]
    IEnumerator Attack()
    {
        parent.Animator.SetBool("isAttacking", true);

        yield return new WaitForSeconds(attackStartOffset);



        //attackCollider.SetActive(true);
    }
}
