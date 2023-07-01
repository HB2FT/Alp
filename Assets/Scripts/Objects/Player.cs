using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public bool isGrounded;
    public float jumpForce;
    public float gravity;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (health > 0)
        {
            //
            // Stop run animation on key up
            //
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("IsRunning", false);
            }

            #region Move Codes

            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * speed * Time.deltaTime;
                animator.SetBool("IsRunning", true);

                if (!isRight)
                {
                    Rotate();
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= -transform.right * speed * Time.deltaTime;
                animator.SetBool("IsRunning", true);

                if (isRight)
                {
                    Rotate();
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    rigidBody.AddForce(new Vector2(0f, jumpForce));
                    //rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
                }
            }

            #endregion
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Terrain") // Zemine deðiyor mu
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // Zemine deðiyor mu
    {
        if (collision.gameObject.name == "Terrain")
        {
            isGrounded = false;
        }
    }
}
