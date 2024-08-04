using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utilities.StateMachine
{

    public enum State
    {
        NONE = 0,
        IDLE = 1,
        MOVE = 2,
        JUMP = 3,
    }
    public abstract class BaseState
    {
        public event Action<State> _OnStateChanged;
        public abstract State Id { get; }
        public abstract void Enter();
        public abstract bool Update();
        public virtual bool FixedUpdate() { return true; }
        public abstract void Exit();
        protected void ChangeState(State newState)
        {
            _OnStateChanged?.Invoke(newState);
        }
    }
}
