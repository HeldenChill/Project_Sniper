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


        NAV_IDLE = 1000,
        NAV_PATROL = 1001,
        NAV_ATTACK = 1002,
        NAV_ALERT = 1003,
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
