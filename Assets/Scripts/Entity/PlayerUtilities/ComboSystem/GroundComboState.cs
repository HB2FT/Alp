using UnityEngine;

namespace Mir.Entity.PlayerUtilities.ComboSystem
{
    public class GroundComboState : SwordBaseState
    {
        public override void OnEnter(StateMachine _stateMachine)
        {
            base.OnEnter(_stateMachine);

            // Attack
            attackIndex = 2;
            duration = .4f;
            animator.SetTrigger("Attack" + attackIndex);
            Debug.Log("Player Atack" + 2 + " -> Attacked");

            // Disable palyer movement
            PlayerMovement.CanMove = false;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (fixedtime >= duration)
            {
                if (shouldCombo.Value)
                {
                    stateMachine.SetNextState(new GroundFinisherState());
                }

                else
                {
                    stateMachine.SetNextStateToMain();
                }
            }
        }

        public override void OnExit()
        {
            base.OnExit();

            // Reactivate palyer movement
            PlayerMovement.CanMove = true;
        }
    }

}