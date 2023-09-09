using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tepegöz : Entity
{
    private AtomicBoolean deathChecker;
    public bool triggered;
    public bool isAttacking;
    public bool collidedWithPlayer;
    public bool isDamaged;
    public readonly float[] triggerArea = {-15f, 15f };
    public int damage = 40;

    int index = 0; // This is for setting isDead variable in animator

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
        if (!IsDead)
        {
            if (target.transform.position.x - transform.position.x > triggerArea[0] 
                && target.transform.position.x - transform.position.x < triggerArea[1]
                && !target.IsDead)
            {
                triggered = true;
            }

            else
            {
                triggered = false;
            }

            #region Move Codes

            if (triggered && !isAttacking && !collidedWithPlayer && !isDamaged)
            {
                if (target.transform.position.x > transform.position.x) // Move right
                {
                    if (!isRight) Rotate(); //Debug.Log("player x > x");

                    transform.position -= speed * Time.deltaTime * transform.right;
                }

                if (target.transform.position.x < transform.position.x)
                {
                    if (isRight) Rotate(); //Debug.Log("player x < x");

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

            if (++index == 10)
            {
                animator.SetBool("isDead", false);
            }
        }
    }

    protected override void OnDeath()
    {
        base.OnDeath();

        animator.SetBool("isDead", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsDead)
        {
            if (collision.gameObject.name == "Player")
            {
                isAttacking = true;
                StartCoroutine(AttackToPlayer());
                collidedWithPlayer = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!IsDead)
        {
            if (collision.gameObject.name == "Player")
            {
                collidedWithPlayer = false;
            }
        }
    }

    public void OnAttackEnd()
    {
        if (collidedWithPlayer)
        {
            Rigidbody2D targetRB = target.gameObject.GetComponent<Rigidbody2D>();
            targetRB.AddForce(new Vector2(-10, 5), ForceMode2D.Impulse); Debug.Log("Player add force");
            target.health -= damage;
        }

        animator.SetBool("isAttacking", false);
        isAttacking = false;
    }

    public void OnHurtEnd()
    {
        animator.SetBool("isDamaged", false);
        isAttacking = false;
        isDamaged = false;
    }

    IEnumerator AttackToPlayer()
    {
        yield return new WaitForSeconds(0.5f);

        if (!isDamaged)
        {
            animator.SetBool("isAttacking", true);
        }
    }
}
