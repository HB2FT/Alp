using UnityEngine;
using UnityInput = UnityEngine.Input;

namespace Mir.Entity.PlayerUtilities.BowSystem
{
    public class BowBaseState : State
    {
        public float duration;
        protected Animator animator;
        protected bool shouldAttack;
        protected string bowStateName;

        public override void OnEnter(StateMachine _stateMachine)
        {
            base.OnEnter(_stateMachine);
            animator = GetComponent<Animator>();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (UnityInput.GetMouseButtonDown(0))
            {
                shouldAttack = true;
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }

}