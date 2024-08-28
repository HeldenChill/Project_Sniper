using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace _Game.Character
{
    using Base;
    using System;
    using Utilities;
    using Utilities.Core.Character.LogicSystem;
    using Utilities.StateMachine;
    #region GROUNDED STATE
    public abstract class GroundedState : BaseLogicState<CharacterStats>
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
            if (Parameter.NavData.Fire.Value)
            {
                Event.Fire();
            }
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
    public class JumpState : BaseLogicState<CharacterStats>
    {
        bool isJumping = false;
        public JumpState(LogicParameter parameter, LogicData data, LogicEvent _event) 
            : base(parameter, data, _event)
        {
        }

        public override State Id => State.JUMP;

        public override void Enter()
        {
            Event.SetVelocityY(Stats.JumpSpeed);
            isJumping = false;
        }

        public override void Exit()
        {
            
        }

        public override bool Update()
        {
            isJumping = !Parameter.WIData.IsGrounded || isJumping;
            if(!isJumping) return false;
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

    public class EnemyIdleState : IdleState
    {
        EnemyNavigationData NavData;
        EnemyLogicEvent EEvent;
        public EnemyIdleState(LogicParameter parameter, LogicData data, LogicEvent _event) : base(parameter, data, _event)
        {
           
        }

        public override State Id => State.IDLE;

        public override void Enter()
        {
            base.Enter();
            NavData = (EnemyNavigationData)Parameter.NavData;

            if (Event is EnemyLogicEvent)
                EEvent = Event as EnemyLogicEvent;
            else
                return;
            NavData._OnAlertStateChange += OnAlertStateChange;
        }

        public override void Exit()
        {
            base.Exit();
            NavData._OnAlertStateChange -= OnAlertStateChange;
        }

        public override bool Update()
        {
            if(!base.Update()) return false;
            return true;
        }

        protected void OnAlertStateChange(ALERT_STATE state)
        {
            EEvent.ChangeAlertState(state);
        }
    }
}