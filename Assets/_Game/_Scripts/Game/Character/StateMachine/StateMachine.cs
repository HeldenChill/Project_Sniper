using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.StateMachine
{
    public class StateMachine
    {
        private BaseState currentState;
        private Dictionary<State, BaseState> states;
        public bool IsDebug;

        public State CurrentState => currentState.Id;
        public Dictionary<State, BaseState> States => states;

        public StateMachine()
        {
            states = new Dictionary<State, BaseState>();
        }

        public void Start(State id)
        {
            currentState = states[id];
            if (IsDebug)
            {
                DevLog.Log(DevId.Hung, $"START: {id}");
            }
        }
        public void AddState(State id, BaseState state)
        {
            if(!states.ContainsKey(id))
            {
                states.Add(id, state);
                states[id]._OnStateChanged += ChangeState;
            }
        }
        public void RemoveState(State id) 
        {
            if (states.ContainsKey(id))
            {
                states[id]._OnStateChanged -= ChangeState;
                states.Remove(id);
            }
        }
        public void ChangeState(State id)
        {
            DevLog.Log(DevId.Hung, $"CHANGE: {CurrentState} -> {id}");
            currentState?.Exit();
            currentState = states[id];
            currentState?.Enter();
        }
        public void Update()
        {
            currentState?.Update();
        }
        public void FixedUpdate()
        {
            currentState?.FixedUpdate();
        }
    }
}