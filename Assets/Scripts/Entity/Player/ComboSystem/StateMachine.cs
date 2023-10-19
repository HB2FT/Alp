using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public int mouseScroll;
    public const int MAX_MOUSE_SCROLL = 2;
    public const int MIN_MOUSE_SCROLL = 0;

    private State mainStateType;

    public State CurrentState { get; private set; }
    private State nextState;

    // Update is called once per frame
    void Update()
    {
        if (nextState != null)
        {
            SetState(nextState);
        }

        if (CurrentState != null)
            CurrentState.OnUpdate();

        float delta;
        if ((delta = Input.mouseScrollDelta.y) != 0)
        {
            ControlMouseScroll(delta);
        }

        

    }

    private void SetState(State _newState)
    {
        nextState = null;
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }
        CurrentState = _newState;
        CurrentState.OnEnter(this);
    }

    public void SetNextState(State _newState)
    {
        if (_newState != null)
        {
            nextState = _newState;
        }
    }

    private void LateUpdate()
    {
        if (CurrentState != null)
            CurrentState.OnLateUpdate();
    }

    private void FixedUpdate()
    {
        if (CurrentState != null)
            CurrentState.OnFixedUpdate();
    }

    public void SetNextStateToMain()
    {
        nextState = mainStateType;
    }

    private void Awake()
    {
        SetNextStateToMain();

    }

    private void ControlMouseScroll(float delta)
    {
        mouseScroll -= (int) delta;

        if (mouseScroll < MIN_MOUSE_SCROLL) mouseScroll = MIN_MOUSE_SCROLL;
        if (mouseScroll > MAX_MOUSE_SCROLL) mouseScroll = MAX_MOUSE_SCROLL;

        if (mouseScroll == 0)
        {
            if (mainStateType.GetType() != typeof(IdleState)) mainStateType = new IdleState();

        }

        if (mouseScroll == 1)
        {
            if (mainStateType.GetType() != typeof(IdleCombatState)) mainStateType = new IdleCombatState();
        }

        if (mouseScroll == 2)
        {
            if (mainStateType.GetType() != typeof(IdleBowState)) mainStateType = new IdleBowState();
        }

        SetNextStateToMain();
    }


    private void OnValidate()
    {
        if (mainStateType == null)
        {
            mainStateType = new IdleState();
        }
    }
}