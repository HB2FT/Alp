using UnityEngine;
using UnityInput = UnityEngine.Input;

namespace Mir.Entity.PlayerUtilities.BowSystem
{
    public class BowPreparingState : BowBaseState
    {
        public override void OnEnter(StateMachine _stateMachine)
        {
            base.OnEnter(_stateMachine);

            bowStateName = "PrepareBow";
            duration = .683f;
            animator.SetTrigger(bowStateName);
            Debug.Log("Bow Preparing");

            PlayerMovement.CanMove = false;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (fixedtime >= duration)
            {
                stateMachine.SetNextState(new BowPreparedState());
            }
            else
            {
                if (UnityInput.GetMouseButtonUp(0))
                {
                    shouldAttack = false;
                    stateMachine.SetNextStateToMain();
                }
            }
        }
        public override void OnExit()
        {
            base.OnExit();

            PlayerMovement.CanMove = true;
        }
    }

}