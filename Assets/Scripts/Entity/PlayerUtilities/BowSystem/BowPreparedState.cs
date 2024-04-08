using System;
using UnityInput = UnityEngine.Input;

namespace Mir.Entity.PlayerUtilities.BowSystem
{
    public class BowPreparedState : BowBaseState
    {
        [Obsolete("Use _Player class")]
        private Player player;

        public float decreasingAmountForPlayerSpeed;

        public override void OnEnter(StateMachine _stateMachine)
        {
            base.OnEnter(_stateMachine);

            duration = .683f;
            bowStateName = "BowPrepared";

            decreasingAmountForPlayerSpeed = 5;

            DecreasePlayerSpeed();

            //player = GetComponent<Player>();
            //player.Speed = player.speedTemp / 4;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (UnityInput.GetMouseButtonUp(0))
            {
                stateMachine.SetNextState(new BowAttackState());
            }
        }

        public override void OnExit()
        {
            base.OnExit();

            IncreasePlayerSpeed();

            //player.Speed = player.speedTemp;
        }

        private void DecreasePlayerSpeed()
        {
            _Player.instance.Speed = _Player.instance.Speed / decreasingAmountForPlayerSpeed;
        }

        private void IncreasePlayerSpeed()
        {
            _Player.instance.Speed = _Player.instance.Speed * decreasingAmountForPlayerSpeed;
        }
    }

}