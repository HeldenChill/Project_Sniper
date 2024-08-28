using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace _Game.Character
{
    using Base;
    using Dynamic.WorldInterface.Data;
    using Utilities;
    using Utilities.Core.Character.NavigationSystem;
    using Utilities.StateMachine;
    using Utilities.Timer;
    public class NavAlertState : BaseNavigationState<CharacterStats>
    {
        protected ALERT_STATE state;
        protected ScanSensorData scanSensorData;
        protected EnemyNavigationData enemyNavigationData;
        bool isSeeingObject;
        public NavAlertState(NavigationParameter parameter, NavigationData data) : base(parameter, data)
        {
        }

        public override State Id => State.NAV_ALERT;

        public override void Enter()
        {
            enemyNavigationData = GetData<EnemyNavigationData>();
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
            if (isSeeingObject && scanSensorData.DetectedObject)
                return false;
            else if(isSeeingObject && !scanSensorData.DetectedObject)
            {
                isSeeingObject = false;
            }
            else if(!isSeeingObject && scanSensorData.DetectedObject)
            {
                if (!scanSensorData.AttackObject) return true;
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
            enemyNavigationData._OnAlertStateChange?.Invoke(state);
        }
    }

    public class NavAttackState : BaseNavigationState<CharacterStats>
    {
        public NavAttackState(NavigationParameter parameter, NavigationData data) : base(parameter, data)
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

    public class NavPatrolState : BaseNavigationState<CharacterStats>
    {
        public NavPatrolState(NavigationParameter parameter, NavigationData data) : base(parameter, data)
        {
        }

        public override State Id => State.NAV_PATROL;

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


    public class NavIdleState : BaseNavigationState<CharacterStats>
    {
        STimer waitTimer;
        ScanSensorData scanSensorData;
        public NavIdleState(NavigationParameter parameter, NavigationData data) : base(parameter, data)
        {
            waitTimer = TimerManager.Ins.PopSTimer();
        }

        public override State Id => State.NAV_IDLE;

        public override void Enter()
        {
            scanSensorData = Parameter.WIData.GetSensorData<ScanSensorData>();
            float waitTime = Random.Range(1f, 6f);
            waitTimer.Start(waitTime, () => ChangeState(State.NAV_PATROL));
        }

        public override void Exit()
        {
            waitTimer.Stop();
            scanSensorData = null;
        }

        public override bool Update()
        {
            scanSensorData ??= Parameter.WIData.GetSensorData<ScanSensorData>();
            if(scanSensorData == null) return false;

            if (scanSensorData.DetectedObject)
            {
                waitTimer.Stop();
                ChangeState(State.NAV_ALERT);
            }
            return true;
        }
    }

}

