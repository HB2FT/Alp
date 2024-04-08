using Mir.Entity.PlayerUtilities.IdleSystem;
using UnityEngine;

namespace Mir.Entity.PlayerUtilities
{
    public class StateMachine : MonoBehaviour
    {

        public _Player player;

        public State mainStateType = new IdleState();

        public State CurrentState { get; private set; }
        private State nextState;

        public static StateMachine instance { get; private set; }

        void Update()
        {
            if (nextState != null)
            {
                SetState(nextState);
            }

            if (CurrentState != null)
                CurrentState.OnUpdate();
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
            if (instance != null)
            {
                Debug.LogError("Found more than one State Machine in the scene");
            }
            instance = this;

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
}