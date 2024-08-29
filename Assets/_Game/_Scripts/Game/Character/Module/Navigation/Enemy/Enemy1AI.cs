using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace _Game.Character
{
    using Utilities.Core.Character.NavigationSystem;
    using Utilities.StateMachine;
    public class Enemy1AI : AbstractNavigationModule<EnemyNavigationData, NavigationParameter>
    {
        StateMachine decision;
        public override void Initialize(EnemyNavigationData Data, NavigationParameter Parameter)
        {
            base.Initialize(Data, Parameter);
            decision = new StateMachine();
            decision.IsDebug = true;
            AddStates(decision);
        }
        public override void StartNavigation()
        {
            decision.Start(State.NAV_IDLE);
        }

        public override void StopNavigation()
        {
            decision.Stop();
        }

        public override void UpdateData()
        {
            decision.Update();
        }

        private void AddStates(StateMachine stateMachine)
        {
            stateMachine.AddState(State.NAV_IDLE ,new NavIdleState(Data, Parameter));
            stateMachine.AddState(State.NAV_ATTACK ,new NavAttackState(Data, Parameter));
            stateMachine.AddState(State.NAV_PATROL ,new NavPatrolState(Data, Parameter));
            stateMachine.AddState(State.NAV_ALERT ,new NavAlertState(Data, Parameter));
        }
    }
}