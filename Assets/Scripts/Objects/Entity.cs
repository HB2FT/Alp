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

    public void Rotate()
    {
        isRight = !isRight;
        transform.Rotate(0f, 180f, 0f);
    }

    protected virtual void OnDeath()
    {
        speed = 0f;
    }
}
