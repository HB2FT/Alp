using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rigidBody;

    public bool isRight;
    public float speed;
    public int health;
    public int maxHealth;
    public const int MIN_HEALTH = 0;

    public void Rotate()
    {
        isRight = !isRight;
        transform.Rotate(0f, 180f, 0f);
    }

    protected virtual void OnDeath()
    {
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

        get
        {
            return animator.GetBool("isDamaged");
        }

        set
        {
            animator.SetBool("isDamaged", value);

            if (value)
            {
                animator.SetTrigger("Hurt");
            }
        }
    }
}
