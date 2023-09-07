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

    public List<PostProcessVolume> postProcessVolumes = new List<PostProcessVolume>();
    public GameObject mainCam;

    public PostProcessVolume postProcessVolume, volumeDeathEffect, volumeLowHealthEffect;
    public PostProcessProfile profileDeath, profileLowHealth;

    public Music music, musicHeartbeatEffect;
    public MusicSession deathMusic, sessionLowHealth;

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
    private AtomicBoolean atomicBoolean_lowHealthSoundEffect1 = new AtomicBoolean(true);
    private AtomicBoolean atomicBoolean_lowHealthSoundEffect2 = new AtomicBoolean(true);

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

        postProcessVolumes.AddRange(mainCam.GetComponents<PostProcessVolume>());

        volumeDeathEffect = postProcessVolumes[0];
        volumeLowHealthEffect = postProcessVolumes[1];

        Time.timeScale = 1;
    }

    void Update()
    {

        if (health > 0)
        {
            //
            // Düþük saðlýk efektleri
            //


            //
            // Stop run animation on key up
            //
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("IsRunning", false);
            }

            #region Move Codes

           /// DEBUG
           /// 

            if (Input.GetKeyDown(KeyCode.X))
            {
                health -= 20;
            }
            
           ///

           if (!bottomBar.activeSelf && isControllable)
           {
                if (Input.GetKey(KeyCode.D))
                {
                    if (!isGrounded) // Havadaysa
                    {
                        transform.position += transform.right * speed * Time.deltaTime;

                        if (!isRight)
                        {
                            Rotate();
                        }
                    }
                    else // Yerseyse
                    {
                        if (!isAttacking) // Saldýrmýyorsa
                        {
                            transform.position += transform.right * speed * Time.deltaTime;

                            if (!isRight)
                            {
                                Rotate();
                            }
                        }
                    }
                
                    animator.SetBool("IsRunning", true);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    if (!isGrounded) // Havadaysa
                    {
                    
                        transform.position -= -transform.right * speed * Time.deltaTime;

                        if (isRight)
                        {
                            Rotate();
                        }
                    }
                    else // Yerdeyse
                    {
                        if (!isAttacking) // Saldýrmýyorsa
                        {
                            transform.position -= -transform.right * speed * Time.deltaTime;

                            if (isRight)
                            {
                                Rotate();
                            }
                        }
                    }

                    animator.SetBool("IsRunning", true);
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

            #region check low health

            if (health <= 25 && atomicBoolean_lowHealthSoundEffect1.Value)
            {
                volumeLowHealthEffect.weight = 0.8f;
                volumeLowHealthEffect.enabled = true; Debug.Log("bool1");

                musicHeartbeatEffect.Play(sessionLowHealth, true);

                atomicBoolean_lowHealthSoundEffect2.Value = true;
            }

            if (health > 25 && atomicBoolean_lowHealthSoundEffect2.Value)
            {
                volumeLowHealthEffect.enabled = false; Debug.Log("bool2");
                musicHeartbeatEffect.Stop();
                atomicBoolean_lowHealthSoundEffect1.Value = true;
            }

            #endregion
        }

        else
        {
            if (deathChecker.Value) OnDeath();

            if (volumeDeathEffect.weight <= 1) volumeDeathEffect.weight += Time.deltaTime * 0.44f; 

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
        if (collision.gameObject.name == "Terrain") // Zemine deðiyor mu
        {
            isGrounded = true;
        }

        if (collision.gameObject.name == "Öcü")
        {
            Öcü collidedÖcü = collision.gameObject.GetComponent<Öcü>();
            //collidedÖcü.health -= damage;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // Zemine deðmiyor mu
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

        volumeDeathEffect.weight = 0;
        volumeDeathEffect.profile = profileDeath;
        volumeDeathEffect.enabled = true;
        isDying = true;
        musicHeartbeatEffect.Stop();

        music.Play(deathMusic, false);

        animator.SetBool("IsDied", true);
    }
}
