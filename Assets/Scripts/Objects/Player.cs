using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.VirtualTexturing;

public class Player : Entity
{
    public GameObject bottomBar;
    public GameObject attackCollider;
    public GameObject deathMenu;

    public PostProcessVolume postProcessVolume;

    public PostProcessProfile profileDeath;

    public Music music;
    public MusicSession deathMusic;

    public bool isGrounded;
    public bool isAttacking = false;
    public bool isControllable = true;
    public bool isDying = false;
    public float jumpForce;
    public float gravity;
    public static int Damage = 20;
    public int damage = Damage;

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

           if (!bottomBar.activeSelf && isControllable)
           {
                if (Input.GetKey(KeyCode.D))
                {
                    if (!isGrounded) // Havadaysa
                    {
                        transform.position += transform.right * speed * Time.deltaTime;
                    }
                    else // Yerseyse
                    {
                        if (!isAttacking) // Sald�rm�yorsa
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
                        if (!isAttacking) // Sald�rm�yorsa
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
                        attackCollider.SetActive(true);
                    }
                }

                #endregion
           }

            #endregion
        }

        else
        {
            if (deathChecker.Value) OnDeath();

            if (postProcessVolume.weight <= 1) postProcessVolume.weight += Time.deltaTime * 0.5f;

            else
            {
                deathMenu.SetActive(true);
            }

            if (Time.timeScale >= 0 && postProcessVolume.weight > 1) Time.timeScale -= Time.deltaTime * 0.8f;
        }

        if (isDying)
        {
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Terrain") // Zemine de�iyor mu
        {
            isGrounded = true;
        }

        if (collision.gameObject.name == "�c�")
        {
            �c� collided�c� = collision.gameObject.GetComponent<�c�>();
            //collided�c�.health -= damage;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // Zemine de�miyor mu
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
        attackCollider.SetActive(false);
    }

    protected override void OnDeath()
    {
        base.OnDeath();

        postProcessVolume.weight = 0;
        postProcessVolume.profile = profileDeath;
        postProcessVolume.enabled = true;
        isDying = true;

        music.Play(deathMusic, false);

        animator.SetBool("IsDied", true);
    }
}
