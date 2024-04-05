using UnityEngine;

namespace Mir.Entity.PlayerUtilities.BowSystem
{
    public class IdleBowState : BowBaseState
    {
        public override void OnEnter(StateMachine _stateMachine)
        {
            base.OnEnter(_stateMachine);

            animator.SetTrigger("HandBow"); Debug.Log("Bow Handed");
        }
    }
}