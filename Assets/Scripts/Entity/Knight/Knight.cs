using Mir.Entity;
using System;
using System.Collections;
using UnityEngine;

public class Knight : Entity
{
    public _Player target;
    public GameObject attackCollider;
    public bool isTriggered;

    [Obsolete("Bu parametre animatörden kaldýrýldý")]
    public bool isAttacking;

    private AtomicBoolean deathChecker = new AtomicBoolean(true);

    public readonly float[] triggerArea = { -10f, 10f };

    [SerializeField] public int Damage;
    private int index = 0; // This is for change isDead animator parameter after a while
    private float dissapearTime = 5f;

    // Area 
    private float boundLeft, boundRight;
    [SerializeField] GameObject borderLeft, borderRight;

    public override void Start()
    {
        base.Start();

        boundLeft = borderLeft.transform.position.x;
        boundRight = borderRight.transform.position.x;
    }

    public override void Update()
    {
        base.Update();

        CheckTrigger();

        //
        // Stay in boundery
        //
        if (transform.position.x < boundLeft) LookAt(Vector2.right);
        if (transform.position.x > boundRight) LookAt(Vector2.left);

        if (health > 0)
        {
            if (CanMove)
            {
                if (isTriggered)
                {
                    transform.position -= Speed * Time.deltaTime * transform.right;

                    animator.SetBool("isWalking", true);
                }

                else
                {
                    animator.SetBool("isWalking", false);
                }
            }
        }

        //else
        //{
        //    if (deathChecker.Value) OnDeath();

        //    if (++index == 10)
        //    {
        //        animator.SetBool("isDead", false);
        //    }
        //}
    }

    protected override void OnDeath()
    {
        base.OnDeath();

        GetComponent<BoxCollider2D>().enabled = false;
        rigidBody.simulated = false;

        animator.SetTrigger("Died");

        Destroy(gameObject, dissapearTime);
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(dissapearTime);


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
        //attackCollider.gameObject.SetActive(false);
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

