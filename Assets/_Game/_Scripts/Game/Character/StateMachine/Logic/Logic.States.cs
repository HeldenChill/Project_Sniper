using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Utilities.Core.Character.LogicSystem;
using Utilities.Core.Character.WorldInterfaceSystem;
using Utilities.StateMachine;

namespace _Game.Character
{
    #region GROUNDED STATE
    public abstract class GroundedState : BaseLogicState<PlayerStats>
    {
        protected GroundedState(LogicParameter parameter, LogicData data, LogicEvent _event) 
            : base(parameter, data, _event)
        {
        }

        public override bool Update()
        {
             if (Parameter.WIData.IsGrounded && Parameter.NavData.Jump.Value)
            {
                ChangeState(State.JUMP);
                return false;
            }
            return true;
        }
    }
    public class IdleState : GroundedState
    {
        public override State Id => State.IDLE;

        public IdleState(LogicParameter parameter, LogicData data, LogicEvent _event) 
            : base(parameter, data, _event) { }
        public override void Enter()
        {
            Event.SetVelocity(Vector2.zero);
        }
        public override bool Update()
        {
            if (!base.Update()) return false;
            if(Parameter.NavData.MoveDirection.sqrMagnitude > 0.0001f)
            {
                ChangeState(State.MOVE);
                return true;
            }
            return true;
        }
        public override void Exit()
        {
            
        }

        
    }
    public class MoveState : GroundedState
    {
        public MoveState(LogicParameter parameter, LogicData data, LogicEvent _event) 
            : base(parameter, data, _event)
        {
        }

        public override State Id => State.MOVE;

        public override void Enter()
        {
            Event.SetVelocityX(Math.Sign(Parameter.NavData.MoveDirection.x) * Stats.Speed);
        }

        public override void Exit()
        {
            
        }

        public override bool Update()
        {
            if (!base.Update()) return false;
            if(Parameter.NavData.MoveDirection.sqrMagnitude < 0.0001f)
            {
                ChangeState(State.IDLE);
            }
            return true;
        }

        public override bool FixedUpdate()
        {
            Event.SetVelocityX(Math.Sign(Parameter.NavData.MoveDirection.x) * Stats.Speed);
            return base.FixedUpdate();
        }
    }
    #endregion
    public class JumpState : BaseLogicState<PlayerStats>
    {
        public JumpState(LogicParameter parameter, LogicData data, LogicEvent _event) 
            : base(parameter, data, _event)
        {
        }

        public override State Id => State.JUMP;

        public override void Enter()
        {
            Event.SetVelocityY(Stats.JumpSpeed);
        }

        public override void Exit()
        {
            
        }

        public override bool Update()
        {
            if (Parameter.WIData.IsGrounded)
            {
                if(Parameter.NavData.MoveDirection.sqrMagnitude > 0.0001f)
                {
                    ChangeState(State.MOVE);
                }
                else
                {
                    ChangeState(State.IDLE);
                }
            }
            return true;
        }

        public override bool FixedUpdate()
        {
            Event.SetVelocityX(Math.Sign(Parameter.NavData.MoveDirection.x) * Stats.Speed);
            return base.FixedUpdate();
        }
    }
}