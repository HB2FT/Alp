using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Entity
{
    public Player player;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public int damage = 25;

    void Start()
    {
        //animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        //transform.position = player.transform.position + new Vector3(10, 0, 0);
        rigidBody.AddForce(new Vector2(10, 0));
    }

    void Update()
    {
        
    }

    public static void Create(Vector2 bounds)
    {
        Arrow arrow = new Arrow();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Player")
        {
            // TODO remove component
        }
    }
}
