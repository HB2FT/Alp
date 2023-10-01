using System;
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

    public Sprite spr_Arrow;

    public bool isGrounded;
    public bool isAttacking = false;
    public bool isControllable = true;
    public bool isDying = false;
    public bool bowHanded = false;
    public float jumpForce;
    public float gravity;
    public static int Damage = 20;
    public int damage = Damage;
    public bool jumpQuery;

    private float speedTemp;

    public const int MAX_MOUSE_SCROLL = 2;
    public const int MIN_MOUSE_SCROLL = 0;
    public int currentMouseScroll = 0;

    public const int attack1 = 0;
    public const int attack2 = 1;
    public const int attack3 = 2;
    public int currentAttackComboIndex = 0;
    public bool attackCombo;

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

        speedTemp = speed;
    }

    void Update()
    {
        if (!IsDead)
        {
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
                health -= 20; attackCollider.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                rigidBody.AddForce(new Vector2(-600, 50));
            }

            ///

            if (!bottomBar.activeSelf && isControllable)
            {
                if (Input.GetKey(KeyCode.D)) // Yay Ku�an�lmam��sa
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
                        if (!isAttacking || bowHanded) // Saldırmıyorsa
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

                if (Input.GetKey(KeyCode.A)) // Yay ku�an�lmam��sa
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
                        if (!isAttacking || bowHanded) // Sald�rm�yorsa
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
                    if (isGrounded && !jumpQuery)
                    {
                        rigidBody.AddForce(new Vector2(0f, jumpForce)); // Jump
                        //rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
                    }
                    else 
                    {
                        if (rigidBody.velocity.y < 0) jumpQuery = true;
                    }
                }

                if (isGrounded && jumpQuery) 
                {
                    rigidBody.AddForce(new Vector2(0f, jumpForce));
                    jumpQuery = false;
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

                bowHanded = currentMouseScroll == 2; // currentMouseScroll değişkeninin 2'ye eşit olma durmu (Eşitse true değilse false olacak)

                if (bowHanded && isAttacking)
                {
                    speed = speedTemp / 4;
                }
                else
                {
                    speed = speedTemp;
                }

                #endregion

                #region Attack

                if (Input.GetMouseButtonDown(0)) // On left click
                {
                    if (currentMouseScroll != 0)
                    {
                        if (currentMouseScroll == 1) // Attack with sword
                        {
                            attackCollider.SetActive(true);
                            currentAttackComboIndex = 0;

                            if (isAttacking)
                            {
                                attackCombo = true;
                            }

                        }

                        animator.SetBool("IsAttacking", true);
                        isAttacking = true;
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {
                    bool bowPrepared = animator.GetBool("BowPrepared");
                    if (bowHanded && !bowPrepared)
                    {
                        isAttacking = false;
                        animator.SetBool("IsAttacking", false);
                    }

                    if (bowHanded && bowPrepared)
                    {
                        animator.SetBool("ArrowThrowable", true);
                    }
                }

                #endregion
            }

            #endregion

            #region check low health

            if (health <= 25 && atomicBoolean_lowHealthSoundEffect1.Value)
            {
                volumeLowHealthEffect.weight = 0.8f;
                volumeLowHealthEffect.enabled = true;

                musicHeartbeatEffect.Play(sessionLowHealth, true);

                atomicBoolean_lowHealthSoundEffect2.Value = true;
            }

            if (health > 25 && atomicBoolean_lowHealthSoundEffect2.Value)
            {
                volumeLowHealthEffect.enabled = false;
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
        if (collision.gameObject.name == "Terrain") // Zemine de�iyor mu
        {
            isGrounded = true;
        }

        if (collision.gameObject.name == "Öcü")
        {
            Öcü collidedÖcü = collision.gameObject.GetComponent<Öcü>();
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

    public void OnFirstAttackAnimationStart()
    {
        attackCombo = false;
        attackCollider.SetActive(true);
    }

    public void OnSecondAttackAnimationStart()
    {
        attackCombo = false;
        attackCollider.SetActive(true);

    }

    public void OnThirdAttackAnimationStart()
    {
        attackCombo = false;
        attackCollider.SetActive(true);
    }

    public void OnFirstAttackAnimationEnd()
    {
        attackCollider.SetActive(false);

        if (!attackCombo)
        {
            animator.SetBool("IsAttacking", false);
            isAttacking = false; Debug.Log("on first attack animation end -> !attack combo");

            currentAttackComboIndex = 0;
            animator.SetInteger("AttackComboIndex", 0);
        }
        else
        {
            animator.SetBool("IsAttackCombo", true);
            currentAttackComboIndex++;
            animator.SetInteger("AttackComboIndex", 1);
        }
    }

    public void OnSecondAttackAnimationEnd()
    {
        attackCollider.SetActive(false);

        if (attackCombo)
        {
            animator.SetBool("IsAttackCombo", true);
            currentAttackComboIndex++;
            animator.SetInteger("AttackComboIndex", 2);
        }
        else
        {
            animator.SetBool("IsAttackCombo", false);

            isAttacking = false;
            animator.SetBool("IsAttacking", false);

            currentAttackComboIndex = 0;
            animator.SetInteger("AttackComboIndex", 0);
        }
    }

    public void OnThirdAttackAnimationEnd()
    {
        attackCombo = false;
        animator.SetBool("IsAttackCombo", attackCombo);
        animator.SetBool("IsAttacking", false);

        isAttacking = false;
        attackCollider.SetActive(false);

        currentAttackComboIndex = 0;
        animator.SetInteger("AttackComboIndex", 0);
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

    protected void BowPrepared()
    {
        animator.SetBool("BowPrepared", true);
    }   

    protected void ArrowThrowed()
    {
        animator.SetBool("IsAttacking", false);
        isAttacking = false;
        animator.SetBool("BowPrepared", false);
        animator.SetBool("ArrowThrowable", false);

        CreateArrow();
    }

    private void CreateArrow() 
    {
        Vector3 bounds = transform.position + new Vector3(1f, 0, 0);

        GameObject arrow = new GameObject();
        arrow.AddComponent<Arrow>();
        arrow.AddComponent<Rigidbody2D>();
        arrow.AddComponent<BoxCollider2D>();
        arrow.AddComponent<SpriteRenderer>();

        arrow.GetComponent<SpriteRenderer>().sprite = spr_Arrow;
        arrow.transform.position = bounds;
    }

    public void SetAttackColliderDeactive()
    {
        attackCollider.SetActive(false);
    }
}
