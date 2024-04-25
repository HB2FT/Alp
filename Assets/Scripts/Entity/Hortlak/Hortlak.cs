using Mir.Entity;
using UnityEngine;

public class Hortlak : Entity
{
    public int Damage;

    public bool isAlive;
    public bool isTriggered;
    public bool isAttacking;
    public bool isDamaged;
    public bool isDead;

    private bool isAliveTemp;
    private float speedTemp;

    public GameObject target; // Player
    public Camera camera_; // For get seen area
    public BoxCollider2D boxCollider;
    public GameObject attackCollider;

    public AtomicBoolean deathChecker = new AtomicBoolean(true);
    private AtomicBoolean speedControllerDuringAttack = new AtomicBoolean(true);

    public override void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        speedTemp = Speed;
        animator.speed = 0;
    }

    public override void Update()
    {
        SetAnimationVariables();
        CheckTrigger();

        #region Check health

        isAliveTemp = health > 0;

        #endregion

        if (isAliveTemp)
        {

            if (isDead || !isAlive) Speed = 0; else Speed = speedTemp;

            if (isTriggered) animator.speed = 1;

            if (animator.GetBool("isTriggered"))
            {
                
                #region Rotation codes

                if (target.transform.position.x < transform.position.x) // Move left
                {
                    if (isRight) Rotate();
                }

                if (target.transform.position.x > transform.position.x) // Move right
                {
                    if (!isRight) Rotate();
                }

                #endregion
                

                transform.position += transform.right * Speed * Time.deltaTime;
            }

            if (animator.GetBool("isAttacking"))
            {
                if (speedControllerDuringAttack.Value) Speed = 0;
            }
            else
            {
                speedControllerDuringAttack.Value = true;

                Speed = speedTemp;
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

        rigidBody.simulated = false;
        boxCollider.enabled = false;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        _Player player = collision.gameObject.GetComponent<_Player>();

        if (player != null)
        {
            isAttacking = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPCBorder"))
        {
            //Rotate();
            Debug.LogError("NPCBorder kullan�m� 0.14.2 s�r�m�nde kald�r�ld�. Onun yerine prefab i�indeki 'bound'lar� kullan�n�z.");
        }
    }

    private void CheckTrigger()
    {
        Plane[] cameraPlanes = GeometryUtility.CalculateFrustumPlanes(camera_);

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
