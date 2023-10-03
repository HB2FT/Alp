using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public float waitForAttack;

    public bool isDamagable;
    public float waitAfterDamage;

    int index = 0; // This is for setting isDead variable in animator

    public Player target;
    public GameObject attackCollider;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

        deathChecker = new AtomicBoolean(true);
        triggered = false;
        isDamagable = true;
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

            if (triggered && !isAttacking && !collidedWithPlayer && !IsDamaged)
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
        }
    }

    protected override void OnDeath()
    {
        base.OnDeath();

        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().simulated = false;

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

    public void OnHurtEnd()
    {
        animator.SetBool("isDamaged", false);
        isAttacking = false;
        isDamaged = false;
    }

    public void OnAttackEnd()
    {
        animator.SetBool("isAttacking", false);
        isAttacking = false;
        attackCollider.SetActive(false);

        TepegözAttackCollider tepegözAttackCollider = attackCollider.GetComponent<TepegözAttackCollider>();

        tepegözAttackCollider.once.Value = true;

    }

    public void EnableAttackCollider()
    {
        attackCollider.SetActive(true);
    }

    IEnumerator AttackToPlayer()
    {
        yield return new WaitForSeconds(waitForAttack);

        if (!isDamaged)
        {
            animator.SetBool("isAttacking", true);
        }
    }

    public void SetIsDamagedFalse()
    {
        IsDamaged = false;
    }

    public void SetAnimatorSpeedZero()
    {
        animator.speed = 0; 
    }

    public bool IsDamagable
    {
        get
        {
            return isDamagable;
        }

        set
        {
            isDamagable = value;

            if (!value)
            {
                StartCoroutine(WaitAfterDamage());
            }
        }
    }

    IEnumerator WaitAfterDamage()
    {
        yield return new WaitForSeconds(waitAfterDamage);

        isDamagable = true;
    }
}
