using UnityEngine;

namespace Mir.Entity.PlayerUtilities.ComboSystem
{
    public class GroundFinisherState : SwordBaseState
    {
        public override void OnEnter(StateMachine _stateMachine)
        {
            base.OnEnter(_stateMachine);

            // Attack
            attackIndex = 3;
            duration = .433f;
            animator.SetTrigger("Attack" + attackIndex);
            Debug.Log("Player Atack" + 3 + " -> Attacked");

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
                    stateMachine.SetNextState(new GroundEntryState()); Debug.Log("Finisher to Entry");
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