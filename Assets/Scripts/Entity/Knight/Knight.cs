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

    [SerializeField] private bool isPlayerInArea;

    private bool isKnockbackCancellingPermited;
    private Vector2 cancelledKnockbackPosition; // Geri tepmenin iptal edilebilmesi için objenin sabitleneceði pozisyon.

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

        //CheckTrigger();

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

            else
            {
                //
                // Check out this code.  
                //
                //isTriggered = false;   
            }
        }

        CancelKnockback();
        CheckIsPlayerInArea();
        FocusTarget();
    }

    private void CancelKnockback()
    {
        if (isKnockbackCancellingPermited)
        {
            transform.position = cancelledKnockbackPosition;
            rigidBody.velocity = Vector2.zero; // Also remove velocity
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

    private void FocusTarget()
    {
        if (isPlayerInArea)
        {
            if (target.transform.position.x < transform.position.x) LookAt(Vector2.left);
            if (target.transform.position.x > transform.position.x) LookAt(Vector2.right);
        }
    }

    private void CheckIsPlayerInArea()
    {
        if (target.transform.position.x < boundRight && target.transform.position.x > boundLeft) 
        {
            isPlayerInArea = true;
        }

        else isPlayerInArea = false;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        
        if (collision.gameObject.CompareTag("Player"))
        {
            isKnockbackCancellingPermited = true;
            cancelledKnockbackPosition = transform.position;
        }
    }

    public override void OnCollisionExit2D(Collision2D collision)
    {
        base.OnCollisionExit2D(collision);

        if (collision.gameObject.CompareTag("Player"))
        {
            isKnockbackCancellingPermited = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPCBorder"))
        {
            Rotate(); Debug.LogError("NPCBorder kullanýmý 0.14.2 sürümünde kaldýrýldý. Onun yerine prefab içindeki 'bound'larý kullanýnýz.");
        }
    }

    public void CheckTrigger()
    {
        float deltaPosition = target.transform.position.x - transform.position.x;

        if (deltaPosition > triggerArea[1] && deltaPosition < triggerArea[0] && !IsDead)
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

