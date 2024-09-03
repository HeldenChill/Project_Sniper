using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace _Game.Character
{
    using Base;
    using System;
    using Utilities.Core.Data;

    using Utilities.Core.Character.LogicSystem;
    using Utilities.StateMachine;
    #region BASE STATE

    #region GROUNDED STATE
    public abstract class GroundedState<D, P, E> : BaseLogicState<CharacterStats, D, P, E>
        where D : LogicData
        where P : LogicParameter
        where E : LogicEvent
    {
        protected GroundedState(D data, P parameter, E _event)
            : base(data, parameter, _event)
        {
        }

        public override bool Update()
        {
            if (Parameter.WIData.IsGrounded && Parameter.NavData.Jump.Value)
            {
                ChangeState(STATE.JUMP);
                return false;
            }
            return true;
        }
    }
    public abstract class IdleState<D, P, E> : GroundedState<D, P, E>
        where D: LogicData
        where P : LogicParameter
        where E : LogicEvent
    {
        public override STATE Id => STATE.IDLE;

        public IdleState(D data, P parameter, E _event)
            : base(data, parameter, _event) { }
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
            if (Parameter.NavData.MoveDirection.sqrMagnitude > 0.0001f)
            {
                ChangeState(STATE.MOVE);
                return true;
            }
            return true;
        }
        public override void Exit()
        {

        }


    }
    public abstract class MoveState<D, P, E> : GroundedState<D, P, E>
        where D : LogicData
        where P : LogicParameter
        where E : LogicEvent
    {
        public MoveState(D data, P parameter, E _event)
            : base(data, parameter, _event)
        {
        }

        public override STATE Id => STATE.MOVE;

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
            if (Parameter.NavData.MoveDirection.sqrMagnitude < 0.0001f)
            {
                ChangeState(STATE.IDLE);
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
    public abstract class JumpState<D, P, E> : BaseLogicState<CharacterStats, D, P, E>
        where D : LogicData
        where P : LogicParameter
        where E : LogicEvent
    {
        bool isJumping = false;
        public JumpState(D data, P parameter, E _event)
            : base(data, parameter, _event)
        {
        }

        public override STATE Id => STATE.JUMP;

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
            if (!isJumping) return false;
            if (Parameter.WIData.IsGrounded)
            {
                if (Parameter.NavData.MoveDirection.sqrMagnitude > 0.0001f)
                {
                    ChangeState(STATE.MOVE);
                }
                else
                {
                    ChangeState(STATE.IDLE);
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
    public class DieState<D, P, E> : BaseLogicState<CharacterStats, D, P, E>
        where D : LogicData
        where P : LogicParameter
        where E : LogicEvent
    {
        public DieState(D data, P parameter, E _event) : base(data, parameter, _event) { }

        public override STATE Id => STATE.DIE;

        public override void Enter()
        {
            Event.SetVelocityX(0);
        }

        public override void Exit()
        {
            
        }

        public override bool Update()
        {
            return true;
        }
    }

    #endregion
    #region PLAYER STATE
    public class PlayerIdleState : IdleState<LogicData, LogicParameter, LogicEvent>
    {
        public PlayerIdleState(LogicData data, LogicParameter parameter, LogicEvent _event) : base(data, parameter, _event)
        {
        }
    }
    public class PlayerMoveState : MoveState<LogicData, LogicParameter, LogicEvent>
    {
        public PlayerMoveState(LogicData data, LogicParameter parameter, LogicEvent _event) : base(data, parameter, _event)
        {
        }
    }
    public class PlayerJumpState : JumpState<LogicData, LogicParameter, LogicEvent>
    {
        public PlayerJumpState(LogicData data, LogicParameter parameter, LogicEvent _event) : base(data, parameter, _event)
        {
        }
    }
    #endregion
    #region ENEMY STATE
    public class EnemyIdleState : IdleState<LogicData, LogicParameter, EnemyLogicEvent>
    {
        EnemyNavigationData NavData;
        ALERT_STATE currentAlertState;
        public EnemyIdleState(LogicData data, LogicParameter parameter, EnemyLogicEvent _event) : base(data, parameter, _event)
        {

        }

        public override STATE Id => STATE.IDLE;

        public override void Enter()
        {
            base.Enter();
            currentAlertState = ALERT_STATE.NONE;
            NavData = Parameter.NavData as EnemyNavigationData;
        }

        public override void Exit()
        {
            base.Exit();
            Event.ChangeAlertState(ALERT_STATE.NONE);
        }

        public override bool Update()
        {
            if (!base.Update()) return false;
            CheckingAlertState(NavData.AlertState);
            return true;
        }

        protected void CheckingAlertState(ALERT_STATE state)
        {
            if (currentAlertState == state) return;
            currentAlertState = state;
            switch (state)
            {
                case ALERT_STATE.NONE:
                    break;
                case ALERT_STATE.START:
                    break;
                case ALERT_STATE.MED_ALERT:
                    break;
                case ALERT_STATE.ALERT:
                    break;
            }
            Event.ChangeAlertState(currentAlertState);
        }
    }
    public class EnemyMoveState : MoveState<LogicData, LogicParameter, EnemyLogicEvent>
    {
        public EnemyMoveState(LogicData data, LogicParameter parameter, EnemyLogicEvent _event) : base(data, parameter, _event)
        {
        }
    }
    public class EnemyJumpState : JumpState<LogicData, LogicParameter, EnemyLogicEvent>
    {
        public EnemyJumpState(LogicData data, LogicParameter parameter, EnemyLogicEvent _event) : base(data, parameter, _event)
        {
        }
    }
    #endregion
}