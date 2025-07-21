using UnityEngine;

namespace Mir.Entity
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField]
        protected Animator animator;
        protected Rigidbody2D rigidBody;

        public bool isRight;
        [SerializeField]
        private float speed;
        public float jumpForce;
        public int health;
        public int maxHealth;
        public const int MIN_HEALTH = 0;
        public bool isGrounded;

        private AtomicBoolean onDeathChecker;

        public virtual void Start()
        {
            animator = GetComponent<Animator>();

            if (animator == null)
            {
                animator = GetComponentInChildren<Animator>();
            }

            rigidBody = GetComponent<Rigidbody2D>();

            health = maxHealth;
            onDeathChecker = new AtomicBoolean(true);
        }

        public virtual void Update()
        {
            if (IsDead)
            {
                if (onDeathChecker.Value) OnDeath();
            }
        }

        public virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Terrain") // Zemine deðiyor mu
            {
                //isGrounded = true;
            }

            if (collision.gameObject.name == "DamagableObjects") OnCollisionWithDamagableObject();
        }

        public virtual void OnCollisionWithDamagableObject()
        {
            health = 0;
        }

        public virtual void OnCollisionExit2D(Collision2D collision) // Zemine deðmiyor mu
        {
            if (collision.gameObject.name == "Terrain")
            {
                //isGrounded = false;
            }
        }

        public void Rotate()
        {
            isRight = !isRight;
            transform.Rotate(0f, 180f, 0f);
        }

        public void LookAt(Vector2 direction)
        {
            if (direction == Vector2.left)
            {
                //
                // Look left
                //

                if (isRight) Rotate();
            }

            if (direction == Vector2.right)
            {
                //
                // Look right
                //

                if (!isRight) Rotate();
            }
        }

        protected virtual void OnDeath()
        {
            health = 0;
            speed = 0f;
        }

        public Animator Animator { get { return animator; } }
        public Rigidbody2D Rigidbody { get { return rigidBody; } }

        public bool IsDead
        {
            get
            {
                return health <= MIN_HEALTH;
            }
        }

        public bool IsDamaged
        {
            set
            {
                if (value)
                {
                    //animator.SetTrigger("Hurt");
                    Debug.Log("Hasar alma animasyonu þimdilik devre dýþý býrakýldý");
                }
            }
        }

        public bool IsGrounded
        {
            get { return isGrounded; }
            set { isGrounded = value; }
        }

        public float Speed
        {
            get
            {
                return speed;
            }

            set { speed = value; }
        }

        public Vector2 FacingDirection
        {
            get
            {
                if (isRight) return Vector2.right;
                else return Vector2.left;
            }
        }
    }

}