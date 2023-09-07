using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tepegöz : Entity
{
    private AtomicBoolean deathChecker;
    public bool triggered;
    public readonly float[] triggerArea = {-15f, 15f };

    public Player target;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

        deathChecker = new AtomicBoolean(true);
        triggered = false;
    }
    void Update()
    {
        if (health > 0)
        {
            if (target.transform.position.x - transform.position.x > triggerArea[0] 
                && target.transform.position.x - transform.position.x < triggerArea[1])
            {
                triggered = true;
            }

            else
            {
                triggered = false;
            }

            #region Move Codes

            if (triggered)
            {
                if (target.transform.position.x > transform.position.x) // Move right
                {
                    if (!isRight) Rotate(); Debug.Log("player x > x");

                    transform.position -= speed * Time.deltaTime * transform.right;
                }

                if (target.transform.position.x < transform.position.x)
                {
                    if (isRight) Rotate(); Debug.Log("player x < x");

                    transform.position -= speed * Time.deltaTime * transform.right;
                }

                animator.SetBool("isRunning", true);
            }

            else
            {
                animator.SetBool("isRunning", false);
            }

            #endregion
        }

        else
        {
            if (deathChecker.Value) OnDeath();
        }
    }

    protected override void OnDeath()
    {
        base.OnDeath();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PlayerAttackCollider")
        {
            health -= target.damage;
        }

        if (collision.name == "Player")
        {

        }
    }

    IEnumerator AttackToPlayer()
    {
        yield return new WaitForSeconds(1f);

        animator.SetBool("isAttacking", true);
    }
}
