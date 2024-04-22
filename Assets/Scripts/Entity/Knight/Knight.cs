using Mir.Entity;
using System;
using System.Collections;
using UnityEngine;

public class Knight : Entity
{
    public _Player target;
    [Obsolete] public GameObject attackCollider;
    public bool isTriggered;
    private BoxCollider2D boxCollider;

    [Obsolete("Bu parametre animatörden kaldýrýldý")]
    public bool isAttacking;

    private bool isCancelKnockback;
    private Vector2 cancelledKnockback; // Geri tepmenin iptal edilebilmesi için objenin sabitleneceði pozisyon.

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
        
        boxCollider = GetComponent<BoxCollider2D>();

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

        CancelKnockback();
    }

    private void CancelKnockback()
    {
        if (isCancelKnockback)
        {
            transform.position = cancelledKnockback;
        }
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

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        
        if (collision.gameObject.CompareTag("Player"))
        {
            //Physics2D.IgnoreCollision(boxCollider, collision.collider);

            isCancelKnockback = true;
            cancelledKnockback = transform.position;
        }
    }

    public override void OnCollisionExit2D(Collision2D collision)
    {
        base.OnCollisionExit2D(collision);

        if (collision.gameObject.CompareTag("Player"))
        {
            isCancelKnockback = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPCBorder"))
        {
            Rotate();
        }
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

