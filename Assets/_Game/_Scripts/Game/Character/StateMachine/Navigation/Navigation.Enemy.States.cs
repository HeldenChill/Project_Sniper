using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace _Game.Character
{
    using Base;
    using Dynamic.WorldInterface.Data;
    using Utilities.Core.Character.NavigationSystem;
    using Utilities.Core.Data;
    using Utilities.StateMachine;
    using Utilities.Timer;
    public class NavAlertState : BaseNavigationState<EnemyNavigationData, NavigationParameter>
    {
        protected ScanSensorData scanSensorData;
        bool isSeeingObject;
        public NavAlertState(EnemyNavigationData data, NavigationParameter parameter) : base(data, parameter)
        {
        }

        public override STATE Id => STATE.NAV_ALERT;

        public override void Enter()
        {
            Data.MoveDirection = Vector2.zero;
            scanSensorData = Parameter.WIData.GetSensorData<ScanSensorData>();
            isSeeingObject = true;
            Data.AlertState = ALERT_STATE.START;
        }

        public override void Exit()
        {
            Data.AlertState = ALERT_STATE.NONE;
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
                if(Data.AlertState != ALERT_STATE.ALERT)
                {
                    Data.AlertState = (ALERT_STATE)((int)Data.AlertState + 1);
                }
                else
                {
                    Data.AlertState = ALERT_STATE.ALERT;
                }
            }  
            return true;
        }      
    }

    public class NavAttackState : BaseNavigationState<EnemyNavigationData, NavigationParameter>
    {
        public NavAttackState(EnemyNavigationData data, NavigationParameter parameter) : base(data, parameter)
        {
        }

        public override STATE Id => STATE.NAV_ATTACK;

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

    public class NavPatrolState : BaseNavigationState<EnemyNavigationData, NavigationParameter>
    {
        STimer timer;
        ScanSensorData scanSensorData;
        DetectGroundEdgeData groundEdgeData;
        public readonly List<Vector2> CAN_MOVE_DIRS;
        Vector2 direction;
        float changeTime;
        public NavPatrolState(EnemyNavigationData data, NavigationParameter parameter) : base(data, parameter)
        {
            CAN_MOVE_DIRS = new List<Vector2>();
        }

        public override STATE Id => STATE.NAV_PATROL;

        public override void Enter()
        {
            timer = TimerManager.Ins.PopSTimer();
            scanSensorData = Parameter.WIData.GetSensorData<ScanSensorData>();
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
            if (scanSensorData.AttackObject != null)
            {
                ChangeState(STATE.NAV_ALERT);
            }
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

            changeTime = Random.Range(Stats<EnemyStats>().Hidden.MinTimePatrol, Stats<EnemyStats>().Hidden.MaxTimePatrol);
            direction = CAN_MOVE_DIRS[Random.Range(0, CAN_MOVE_DIRS.Count)];
        }
        protected void UpdatePatrol()
        {
            UpdateRandomPropertys();
            Data.MoveDirection = direction;
            //DEV: Cannot Loop Here Because Trigger Before Stop
            timer.Start(changeTime, UpdatePatrol);
        }
    }


    public class NavIdleState : BaseNavigationState<EnemyNavigationData, NavigationParameter>
    {
        STimer waitTimer;
        ScanSensorData scanSensorData;
        public NavIdleState(EnemyNavigationData data, NavigationParameter parameter) : base(data, parameter)
        {
            waitTimer = TimerManager.Ins.PopSTimer();
        }

        public override STATE Id => STATE.NAV_IDLE;

        public override void Enter()
        {
            scanSensorData = Parameter.WIData.GetSensorData<ScanSensorData>();
            float waitTime = Random.Range(Stats<EnemyStats>().Hidden.MinTimeIdle, Stats<EnemyStats>().Hidden.MaxTimeIdle);
            waitTimer.Start(waitTime, () => ChangeState(STATE.NAV_PATROL));
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
                ChangeState(STATE.NAV_ALERT);
            }
            return true;
        }
    }

}

