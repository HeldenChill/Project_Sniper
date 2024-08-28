using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace _Game.Character
{
    using Utilities.Core.Character.NavigationSystem;
    using Utilities.StateMachine;
    public class Enemy1AI : AbstractNavigationModule
    {
        StateMachine decision;
        public override void Initialize(NavigationData Data, NavigationParameter Parameter)
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
            stateMachine.AddState(State.NAV_IDLE ,new NavIdleState(Parameter, Data));
            stateMachine.AddState(State.NAV_ATTACK ,new NavAttackState(Parameter, Data));
            stateMachine.AddState(State.NAV_PATROL ,new NavPatrolState(Parameter, Data));
            stateMachine.AddState(State.NAV_ALERT ,new NavAlertState(Parameter, Data));
        }
    }
}