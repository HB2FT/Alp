using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBaseState : State
{
    public float duration;
    protected Animator animator;

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        animator = GetComponent<Animator>();
    }
}
