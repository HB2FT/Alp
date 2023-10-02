using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hortlak : Entity
{
    public bool isAlive;
    public bool isTriggered;
    public bool isAttacking;
    public bool isDamaged;
    public bool isDead;

    private bool isAliveTemp;
    private float speedTemp;

    public GameObject target; // Player
    public Camera camera; // For get seen area
    public BoxCollider2D boxCollider;
    public GameObject attackCollider;

    public AtomicBoolean deathChecker = new AtomicBoolean(true);
    private AtomicBoolean speedControllerDuringAttack = new AtomicBoolean(true);

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        speedTemp = speed;
        animator.speed = 0;
    }

    void Update()
    {
        SetAnimationVariables();
        CheckTrigger();

        #region Check health

        isAliveTemp = health > 0;

        #endregion

        if (isAliveTemp)
        {

            if (isDead || !isAlive) speed = 0; else speed = speedTemp;

            if (isTriggered) animator.speed = 1;

            if (animator.GetBool("isTriggered"))
            {
                #region Move codes

                if (target.transform.position.x < transform.position.x) // Move left
                {
                    if (isRight) Rotate();

                    transform.position += transform.right * speed * Time.deltaTime;
                }

                if (target.transform.position.x > transform.position.x) // Move right
                {
                    if (!isRight) Rotate();

                    transform.position += transform.right * speed * Time.deltaTime;
                }

                #endregion
            }

            if (animator.GetBool("isAttacking"))
            {
                if (speedControllerDuringAttack.Value) speed = 0;
            }
            else
            {
                speedControllerDuringAttack.Value = true;

                speed = speedTemp;
            }
        }
        else
        {
            if (deathChecker.Value) OnDeath();
        }
    }

    protected override void OnDeath()
    {
        base.OnDeath();

        isAlive = false;
        isDead = true;

        rigidBody.gravityScale = 0;
        boxCollider.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            isAttacking = true;
        }
    }

    private void CheckTrigger()
    {
        Plane[] cameraPlanes = GeometryUtility.CalculateFrustumPlanes(camera);

        isTriggered = GeometryUtility.TestPlanesAABB(cameraPlanes, boxCollider.bounds);
    }

    private void SetAnimationVariables()
    {
        animator.SetBool("isAlive", isAlive);
        animator.SetBool("isTriggered", isTriggered);
        animator.SetBool("isAttacking", isAttacking);
        animator.SetBool("isDamaged", isDamaged);
        animator.SetBool("isDead", isDead);
    }

    public void SetIsDamagedFalse()
    {
        animator.SetBool("isDamaged", false);
    }

    public void SetIsAliveTrue()
    {
        isAlive = true;
    }

    public void OnAttackEnd()
    {
        isAttacking = false;

        attackCollider.gameObject.SetActive(false);
    }

    public void SetAttackColliderActive()
    {
        attackCollider.gameObject.SetActive(true);
    }

    public void FreezeAnimation()
    {
        animator.speed = 0f;
    }
}
