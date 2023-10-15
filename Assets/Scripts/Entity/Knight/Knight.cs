using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Knight : Entity
{
    public Player target;
    public GameObject attackCollider;
    public bool isTriggered;
    public bool isAttacking;

    private AtomicBoolean deathChecker = new AtomicBoolean(true);

    public readonly float[] triggerArea = {-10f, 10f };

    private int index = 0; // This is for change isDead animator parameter after a while

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckTrigger();Debug.Log(CanMove);

        isAttacking = animator.GetBool("isAttacking");

        if (health > 0)
        {
            if (CanMove)
            {
                if (isTriggered && !isAttacking)
                {
                    /*
                    if (target.transform.position.x > transform.position.x)
                    {
                        if (!isRight) Rotate();

                        transform.position -= speed * Time.deltaTime * transform.right;
                    }

                    if (target.transform.position.x < transform.position.x)
                    {
                        if (isRight) Rotate();

                        transform.position -= speed * Time.deltaTime * transform.right;
                    }
                    */

                    transform.position -= speed * Time.deltaTime * transform.right;

                    animator.SetBool("isWalking", true);
                }

                else
                {
                    animator.SetBool("isWalking", false);
                }
            }
        }

        else
        {
            if (deathChecker.Value) OnDeath();

            if (++index == 10)
            {
                animator.SetBool("isDead", false);
            }
        }
    }

    protected override void OnDeath() 
    {
        base.OnDeath();

        GetComponent<BoxCollider2D>().enabled = false;
        rigidBody.simulated = false;
        attackCollider.SetActive(false);

        BoxCollider2D[] collidersInChildren = GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D currentCollider in collidersInChildren)
        {
            currentCollider.enabled = false;
        }

        //animator.SetBool("isDead", true);
        animator.SetTrigger("Died");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPCBorder"))
        {
            Rotate();
        }
    }

    public void EnableAttackCollider()
    {

    }

    public void OnAttackEnd() 
    {
        //animator.SetBool("isAttacking", false);
        //animator.SetTrigger("Attack");
        attackCollider.gameObject.SetActive(false);
    }

    public void CheckTrigger() 
    {
        float deltaPosition = target.transform.position.x - transform.position.x;

        if (deltaPosition > triggerArea[0] && deltaPosition < triggerArea[1] && !IsDead)
        {
            isTriggered = true;
        }

        else 
        {
            isTriggered = false;
        }
    }

    public bool CanMove
    {
        get
        {
            return !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || !animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt");
        }
    }
}
