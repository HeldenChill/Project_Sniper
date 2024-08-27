using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Character
{
    using Utilities.Core.Character.NavigationSystem;
    using Utilities.StateMachine;
    public abstract class BaseNavigationState<T> : BaseState where T : ScriptableObject
    {
        protected NavigationParameter Parameter;
        protected NavigationData Data;
        private T stats;
        public T Stats => stats ??= Parameter.GetStats<T>();
        public BaseNavigationState(NavigationParameter parameter, NavigationData data)
        {
            Parameter = parameter;
            Data = data;
        }
    }
}

