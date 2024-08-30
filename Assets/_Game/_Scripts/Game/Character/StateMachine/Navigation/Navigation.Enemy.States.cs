using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace _Game.Character
{
    using Base;
    using Dynamic.WorldInterface.Data;
    using Utilities.Core.Character.NavigationSystem;
    using Utilities.StateMachine;
    using Utilities.Timer;
    public class NavAlertState : BaseNavigationState<EnemyStats, EnemyNavigationData, NavigationParameter>
    {
        protected ALERT_STATE state;
        protected ScanSensorData scanSensorData;
        bool isSeeingObject;
        public NavAlertState(EnemyNavigationData data, NavigationParameter parameter) : base(data, parameter)
        {
        }

        public override State Id => State.NAV_ALERT;

        public override void Enter()
        {
            scanSensorData = Parameter.WIData.GetSensorData<ScanSensorData>();
            isSeeingObject = true;
            ChangeAlertState(ALERT_STATE.START);
        }

        public override void Exit()
        {
            ChangeAlertState(ALERT_STATE.NONE);
        }

        public override bool Update()
        {
            //DevLog.Log(DevId.Hung, $"IS SEE = {isSeeingObject}, DETECTED: {scanSensorData.DetectedObject}");
            if (isSeeingObject && scanSensorData.AttackObject)
                return false;
            else if(isSeeingObject && !scanSensorData.AttackObject)
            {
                isSeeingObject = false;
            }
            else if(!isSeeingObject && scanSensorData.AttackObject)
            {
                isSeeingObject = true;
                if(state != ALERT_STATE.ALERT)
                {
                    ChangeAlertState((ALERT_STATE)((int)state + 1));
                }
                else
                {
                    ChangeAlertState(ALERT_STATE.ALERT);
                }
            }  
            return true;
        }

        protected void ChangeAlertState(ALERT_STATE state)
        {
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
            this.state = state;
            Data._OnAlertStateChange?.Invoke(state);
        }
    }

    public class NavAttackState : BaseNavigationState<EnemyStats, EnemyNavigationData, NavigationParameter>
    {
        public NavAttackState(EnemyNavigationData data, NavigationParameter parameter) : base(data, parameter)
        {
        }

        public override State Id => State.NAV_ATTACK;

        public override void Enter()
        {
            
        }

        public override void Exit()
        {
            
        }

        public override bool Update()
        {
            return true;
        }
    }

    public class NavPatrolState : BaseNavigationState<EnemyStats, EnemyNavigationData, NavigationParameter>
    {
        STimer timer;
        DetectGroundEdgeData groundEdgeData;
        public readonly List<Vector2> CAN_MOVE_DIRS;
        Vector2 direction;
        float changeTime;
        public NavPatrolState(EnemyNavigationData data, NavigationParameter parameter) : base(data, parameter)
        {
            CAN_MOVE_DIRS = new List<Vector2>();
        }

        public override State Id => State.NAV_PATROL;

        public override void Enter()
        {
            timer = TimerManager.Ins.PopSTimer();
            groundEdgeData = Parameter.WIData.GetSensorData<DetectGroundEdgeData>();
            UpdatePatrol();
        }

        public override void Exit()
        {
            timer.Stop();
            TimerManager.Ins.PushSTimer(timer);
            timer = null;
        }

        public override bool Update()
        {
            if (!groundEdgeData.LeftEdgeDetected)
            {
                if(direction.x < 0)
                {
                    direction = Vector2.right;
                    Data.MoveDirection = direction;
                }
            }

            if(!groundEdgeData.RightEdgeDetected)
            {
                if(direction.x > 0)
                {
                    direction = Vector2.left;
                    Data.MoveDirection = direction;
                }
            }
            return true;
        }

        protected void UpdateRandomPropertys()
        {
            CAN_MOVE_DIRS.Clear();
            if (groundEdgeData.LeftEdgeDetected)
            {
                CAN_MOVE_DIRS.Add(Vector2.left);
            }

            if(groundEdgeData.RightEdgeDetected)
            {
                CAN_MOVE_DIRS.Add(Vector2.right);
            }

            changeTime = Random.Range(Stats.Hidden.MinTimePatrol, Stats.Hidden.MaxTimePatrol);
            direction = CAN_MOVE_DIRS[Random.Range(0, CAN_MOVE_DIRS.Count)];
        }
        protected void UpdatePatrol()
        {
            UpdateRandomPropertys();
            Data.MoveDirection = direction;
            timer.Start(changeTime, UpdatePatrol);
        }
    }


    public class NavIdleState : BaseNavigationState<EnemyStats, EnemyNavigationData, NavigationParameter>
    {
        STimer waitTimer;
        ScanSensorData scanSensorData;
        public NavIdleState(EnemyNavigationData data, NavigationParameter parameter) : base(data, parameter)
        {
            waitTimer = TimerManager.Ins.PopSTimer();
        }

        public override State Id => State.NAV_IDLE;

        public override void Enter()
        {
            scanSensorData = Parameter.WIData.GetSensorData<ScanSensorData>();
            float waitTime = Random.Range(Stats.Hidden.MinTimeIdle, Stats.Hidden.MaxTimeIdle);
            waitTimer.Start(waitTime, () => ChangeState(State.NAV_PATROL));
        }

        public override void Exit()
        {
            waitTimer.Stop();
            scanSensorData = null;
        }

        public override bool Update()
        {
            if(scanSensorData == null) return false;

            if (scanSensorData.AttackObject)
            {
                waitTimer.Stop();
                ChangeState(State.NAV_ALERT);
            }
            return true;
        }
    }

}

