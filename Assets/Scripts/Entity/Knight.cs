using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Entity
{
    public Player target;
    public bool isTriggered;

    private AtomicBoolean deathChecker = new AtomicBoolean(true);

    public readonly float[] triggerArea = {-10f, 10f };

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckTrigger();

        if (isTriggered)
        {
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

            animator.SetBool("isWalking", true);
        }

        else 
        {
            animator.SetBool("isWalking", false);
        }

        if (IsDead && deathChecker.Value) 
        {
            OnDeath();
        }
    }

    protected override void OnDeath() 
    {
        base.OnDeath();

        animator.SetBool("isDead", true);
    }

    public void OnAttackEnd() 
    {
        animator.SetBool("isAttacking", false);
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
}
