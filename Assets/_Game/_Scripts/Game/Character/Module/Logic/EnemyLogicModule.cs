using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Character
{
    using Utilities.Core.Character.LogicSystem;
    using Utilities.StateMachine;
    using System;

    public class EnemyLogicModule : AbstractLogicModule<LogicData, LogicParameter, EnemyLogicEvent>
    {
        StateMachine stateMachine;
        public override void Initialize(LogicData Data, LogicParameter Parameter, EnemyLogicEvent Event)
        {
            base.Initialize(Data, Parameter, Event);

            stateMachine = new StateMachine();
            stateMachine.IsDebug = true;

            stateMachine.AddState(State.IDLE, new EnemyIdleState(Data, Parameter, Event));
            stateMachine.AddState(State.MOVE, new EnemyMoveState(Data, Parameter, Event));
            stateMachine.AddState(State.JUMP, new EnemyJumpState(Data, Parameter, Event));

        }

        private void Start()
        {
            stateMachine.Start(State.IDLE);
        }
        public override void UpdateData()
        {
            stateMachine.Update();
        }

        public override void FixedUpdateData()
        {
            stateMachine.FixedUpdate();
        }
    }
}