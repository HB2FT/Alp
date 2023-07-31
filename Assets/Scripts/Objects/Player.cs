using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Player : Entity
{
    public GameObject bottomBar;

    public bool isGrounded;
    public bool isAttacking = false;
    public float jumpForce;
    public float gravity;

    public const int MAX_MOUSE_SCROLL = 1;
    public const int MIN_MOUSE_SCROLL = 0;
    public int currentMouseScroll = 0;

    private AtomicBoolean deathChecker = new AtomicBoolean(true);

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

           if (!bottomBar.activeSelf)
            {
                 if (Input.GetKey(KeyCode.D))
            {
                if (!isGrounded) // Havadaysa
                {
                    transform.position += transform.right * speed * Time.deltaTime;
                }
                else // Yerseyse
                {
                    if (!isAttacking) // Saldırmıyorsa
                    {
                        transform.position += transform.right * speed * Time.deltaTime;
                    }
                }
                
                animator.SetBool("IsRunning", true);

                if (!isRight)
                {
                    Rotate();
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                if (!isGrounded) // Havadaysa
                {
                    
                    transform.position -= -transform.right * speed * Time.deltaTime;
                    
                    
                }
                else // Yerdeyse
                {
                    if (!isAttacking) // Saldırmıyorsa
                    {
                        transform.position -= -transform.right * speed * Time.deltaTime;
                    }
                }

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

            #region Hand Weapon

            if (Input.mouseScrollDelta.y < 0 && currentMouseScroll < MAX_MOUSE_SCROLL)
            {
                currentMouseScroll++;
                animator.SetInteger("MouseScroll", currentMouseScroll);
            }

            if (Input.mouseScrollDelta.y > 0 && currentMouseScroll > MIN_MOUSE_SCROLL)
            {
                currentMouseScroll--;
                animator.SetInteger("MouseScroll", currentMouseScroll);
            }

            #endregion

            #region Attack

            if (Input.GetMouseButtonDown(0)) // On left click
            {
                if (currentMouseScroll != 0)
                {
                    animator.SetBool("IsAttacking", true);
                    isAttacking = true;
                }
            }

            #endregion
            }

            #endregion
        }

        else
        {
            if (deathChecker.Value) OnDeath();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Terrain") // Zemine değiyor mu
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // Zemine değmiyor mu
    {
        if (collision.gameObject.name == "Terrain")
        {
            isGrounded = false;
        }
    }

    public void OnAttackAnimationEnd()
    {
        animator.SetBool("IsAttacking", false);
        isAttacking = false;
    }

    protected override void OnDeath()
    {
        base.OnDeath();

        animator.SetBool("IsDied", true);
    }
}
