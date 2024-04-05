﻿using UnityEngine;

namespace Mir.Entity.PlayerUtilities.IdleSystem
{
    public class IdleBaseState : State
    {
        public float duration;
        protected Animator animator;

        public override void OnEnter(StateMachine _stateMachine)
        {
            base.OnEnter(_stateMachine);

            animator = GetComponent<Animator>();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}