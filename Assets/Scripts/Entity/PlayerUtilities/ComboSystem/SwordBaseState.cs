using Mir.Objects.Items;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Mir.Entity.PlayerUtilities.ComboSystem
{
    public class SwordBaseState : State
    {
        [Obsolete]
        private PlayerInput playerInput;

        public float duration;
        protected Animator animator;
        protected AtomicBoolean shouldCombo;
        protected int attackIndex;
        protected bool isAttackPressed;

        public override void OnEnter(StateMachine _stateMachine)
        {
            base.OnEnter(_stateMachine);

            animator = GetComponent<Animator>();

            shouldCombo = new AtomicBoolean(false);

            SetPlayerAttackColliderState(true);

            //playerInput = new PlayerInput();

            //playerInput.Enable();

            //playerInput.Player.Attack.started += Attack;

            Sword.instance.onUse += UseSword;

        }

        void SetPlayerAttackColliderState(bool state)
        {
            if (StateMachine.instance.CurrentState.GetType() != typeof(IdleCombatState))
            {
                PlayerAttackCollider.instance.gameObject.SetActive(state);
            }
        }

        void Attack(InputAction.CallbackContext context)
        {
            isAttackPressed = context.ReadValueAsButton();
        }

        void UseSword()
        {
            shouldCombo.Value = true;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            //if (isAttackPressed)
            //{
            //    shouldCombo = true;
            //    isAttackPressed = false;
            //}
        }

        public override void OnExit()
        {
            base.OnExit();

            SetPlayerAttackColliderState(false);

            //playerInput.Disable();
        }
    }
}