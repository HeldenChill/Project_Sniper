using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Core.Character.NavigationSystem;
using Utilities.StateMachine;


namespace _Game.Character
{
    public class NavAlertState : BaseNavigationState<CharacterStats>
    {
        public NavAlertState(NavigationParameter parameter, NavigationData data) : base(parameter, data)
        {
        }

        public override State Id => State.NAV_ALERT;

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
        public NavIdleState(NavigationParameter parameter, NavigationData data) : base(parameter, data)
        {
        }

        public override State Id => State.NAV_IDLE;

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

}

