using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Character
{
    using Utilities.Core.Character.LogicSystem;
    using Utilities.StateMachine;
    using System;

    public class EnemyLogicModule : AbstractLogicModule
    {
        StateMachine stateMachine;
        public override void Initialize(LogicData Data, LogicParameter Parameter, LogicEvent Event)
        {
            base.Initialize(Data, Parameter, Event);

            stateMachine = new StateMachine();
            stateMachine.IsDebug = true;

            stateMachine.AddState(State.IDLE, new EnemyIdleState(Parameter, Data, Event));
            stateMachine.AddState(State.MOVE, new MoveState(Parameter, Data, Event));
            stateMachine.AddState(State.JUMP, new JumpState(Parameter, Data, Event));

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