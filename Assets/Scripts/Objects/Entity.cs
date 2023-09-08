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

    public bool IsDead
    {
        get
        {
            return health <= MIN_HEALTH;
        }
    }
}
