using System.Collections;
using UnityEngine;

namespace Mir.Entity.Archer
{
    public class Archer : Entity
    {
        [SerializeField] private GameObject ArrowPrefab;
        [SerializeField] private GameObject ArrowSpawnPoint;

        private BoxCollider2D boxCollider;
        [SerializeField] private new Camera camera;

        [SerializeField] private float waitForAttack;
        private float attackTimer;
        
        public override void Start()
        {
            base.Start();

            boxCollider = GetComponent<BoxCollider2D>();
        }

        public override void Update()
        {
            base.Update();

            Debug();

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
        }

        IEnumerator ThrowArrow()
        {
            yield return new WaitForSeconds(0.6f);

            CreateArrow();
        }

        private void Debug()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.X))
            {
                CreateArrow();
            }
        }

        public void CreateArrow()
        {
            Vector2 direction;

            if (transform.rotation.y == 180 || transform.rotation.y == -180)
            {
                direction = Vector2.left;
            }

            else
            {
                direction = Vector2.right;
            }

            Arrow2.Create(ArrowPrefab, ArrowSpawnPoint.transform.position, direction);
            //Arrow2 arrow = Instantiate(ArrowPrefab, ArrowSpawnPoint.transform.position, Quaternion.identity).GetComponent<Arrow2>();
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
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
                return GeometryUtility.TestPlanesAABB(planes, boxCollider.bounds);
            }
        }
    }
}
