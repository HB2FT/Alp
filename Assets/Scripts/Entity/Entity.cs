using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    protected Animator animator;
    protected Rigidbody2D rigidBody;

    public bool isRight;
    [SerializeField]    
    private float speed;
    public float jumpForce;
    public int health;
    public int maxHealth;
    public const int MIN_HEALTH = 0;
    public bool isGrounded;

    private AtomicBoolean onDeathChecker;

    public virtual void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }

        rigidBody = GetComponent<Rigidbody2D>();

        health = maxHealth;
        onDeathChecker = new AtomicBoolean(true);
    }

    public virtual void Update()
    {
        if (IsDead)
        {
            if (onDeathChecker.Value) OnDeath();
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Terrain") // Zemine de�iyor mu
        {
            //isGrounded = true;
        }

        if (collision.gameObject.name == "DamagableObjects")
        {
            health = 0;
        }
    }

    public virtual void OnCollisionExit2D(Collision2D collision) // Zemine de�miyor mu
    {
        if (collision.gameObject.name == "Terrain")
        {
            //isGrounded = false;
        }
    }

    public void Rotate()
    {
        isRight = !isRight;
        transform.Rotate(0f, 180f, 0f);
    }

    protected virtual void OnDeath()
    {
        health = 0;
        speed = 0f;
    }

    public Animator Animator { get { return animator; } }
    public Rigidbody2D Rigidbody { get { return rigidBody; } }

    public bool IsDead
    {
        get
        {
            return health <= MIN_HEALTH;
        }
    }

    public bool IsDamaged
    {
        set
        {
            if (value)
            {
                animator.SetTrigger("Hurt");
            }
        }
    }

    public bool IsGrounded
    {
        get { return isGrounded; }
        set { isGrounded = value; }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set { speed = value; }
    }
}
