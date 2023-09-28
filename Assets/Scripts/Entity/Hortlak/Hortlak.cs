using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hortlak : Entity
{
    private bool isAlive;
    private bool isTriggered;
    private bool isAttacking;
    private bool isDamaged;
    private bool isDead;

    public GameObject target; // Player

    public AtomicBoolean deathChecker = new AtomicBoolean(true);

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        #region Check health

        isAlive = health > 0;

        #endregion

        if (animator.GetBool("isAlive"))
        {
            ///
            /// Debug

            animator.SetBool("isTriggered", true);

            ///

            if (isDead || !isAlive) speed = 0; else speed = 1;

            #region Move codes

            if (target.transform.position.x < transform.position.x) // Move left
            {
                if (isRight) Rotate();

                transform.position += transform.right * speed * Time.deltaTime;
            }

            if (target.transform.position.x > transform.position.x) // Move right
            {
                if (!isRight) Rotate();

                transform.position += transform.right * speed * Time.deltaTime;
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

        animator.SetBool("isAlive", false);
        animator.SetBool("isDead", true);
    }

    public void SetIsDamagedFalse()
    {
        animator.SetBool("isDamaged", false);
    }

    public void SetIsAliveTrue()
    {
        animator.SetBool("isAlive", true);
    }
}
