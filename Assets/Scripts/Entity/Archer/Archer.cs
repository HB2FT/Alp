using System.Collections;
using UnityEngine;

namespace Mir.Entity.Archer
{
    public class Archer : Entity
    {
        [SerializeField] private GameObject ArrowPrefab;
        [SerializeField] private GameObject ArrowSpawnPoint;

        private bool isKnockbackCancellingPermited;
        private Vector2 cancelledKnockbackPosition; // Geri tepmenin iptal edilebilmesi için objenin sabitleneceði pozisyon.

        private BoxCollider2D boxCollider;
        [SerializeField] private new Camera camera;

        [SerializeField] private float waitForAttack;
        private float attackTimer;

        [SerializeField] private float throwingForce;

        [SerializeField] private _Player target;
        
        public override void Start()
        {
            base.Start();

            boxCollider = GetComponent<BoxCollider2D>();

            if (target == null) target = _Player.instance;
        }

        public override void Update()
        {
            base.Update();

            if (!IsDead)
            {
                if (IsTriggered)
                {
                    attackTimer += Time.deltaTime;

                    if (CurrentAnimationClip.name != "Attack")
                    {
                        if (attackTimer > (0.6f + waitForAttack))
                        {
                            animator.SetTrigger("Attack");
                            attackTimer = 0f;

                            StartCoroutine(ThrowArrow());
                        }
                    }
                }

                else
                {
                    attackTimer = 0f;
                }

                FocusOnTarget();
                CancelKnockback();
            }
        }

        protected override void OnDeath()
        {
            base.OnDeath();

            boxCollider.enabled = false;
            rigidBody.simulated = false;

            animator.SetTrigger("Death");
            Disappear();
        }

        private void Disappear()
        {
            StartCoroutine(DisappearCoroutine());
        }
        IEnumerator DisappearCoroutine()
        {
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }

        private void CancelKnockback()
        {
            if (isKnockbackCancellingPermited)
            {
                transform.position = cancelledKnockbackPosition;
                rigidBody.velocity = Vector2.zero; // Also remove velocity
            }
        }

        public override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);

            if (collision.gameObject.CompareTag("Player"))
            {
                isKnockbackCancellingPermited = true;
                cancelledKnockbackPosition = transform.position;
            }
        }

        public override void OnCollisionExit2D(Collision2D collision)
        {
            base.OnCollisionExit2D(collision);

            if (collision.gameObject.CompareTag("Player"))
            {
                isKnockbackCancellingPermited = false;
            }
        }

        private void FocusOnTarget()
        {
            if (target.transform.position.x < transform.position.x && isRight) Rotate();
            if (target.transform.position.x > transform.position.x && !isRight) Rotate();
        }

        IEnumerator ThrowArrow()
        {
            yield return new WaitForSeconds(0.6f);

            CreateArrow();
        }

        public void CreateArrow()
        {
            Arrow2.Create(ArrowPrefab, ArrowSpawnPoint.transform.position, isRight, throwingForce);
        }

        public AnimationClip CurrentAnimationClip
        {
            get
            {
                return animator.GetCurrentAnimatorClipInfo(0)[0].clip;
            }
        }

        public bool IsTriggered
        {
            get
            {
                if (_Player.instance.IsDead) return false;

                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
                return GeometryUtility.TestPlanesAABB(planes, boxCollider.bounds);
            }
        }
    }
}
