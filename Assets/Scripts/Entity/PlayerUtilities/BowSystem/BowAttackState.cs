using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Mir.Entity.PlayerUtilities.BowSystem
{
    public class BowAttackState : BowBaseState
    {
        public override void OnEnter(StateMachine _stateMachine)
        {
            base.OnEnter(_stateMachine);

            duration = .133f;
            bowStateName = "ReleaseBow";
            animator.SetTrigger(bowStateName); Debug.Log(bowStateName);

            CreateArrow();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (fixedtime >= duration)
            {
                stateMachine.SetNextStateToMain();
            }
        }

        private void CreateArrow()
        {
            Debug.Log("Creating arrow");

            Vector3 bounds = _Player.instance.transform.position + new Vector3(1f, 0, 0);

            GameObject arrow = new GameObject();
            arrow.AddComponent<Arrow>();
            arrow.AddComponent<Rigidbody2D>();
            arrow.AddComponent<BoxCollider2D>();
            arrow.AddComponent<SpriteRenderer>();

            arrow.GetComponent<SpriteRenderer>().sprite = _Player.instance.spr_Arrow;
            arrow.transform.position = bounds;
        }
    }
}