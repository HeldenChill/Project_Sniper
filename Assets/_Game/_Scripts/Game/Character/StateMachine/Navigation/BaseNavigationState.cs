using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Character
{
    using Utilities.Core.Character.NavigationSystem;
    using Utilities.StateMachine;
    public abstract class BaseNavigationState<T, D, P> : BaseState where T : ScriptableObject
        where D : NavigationData
        where P : NavigationParameter
    {
        protected P Parameter;
        protected D Data;
        private T stats;
        public T Stats => stats ??= Parameter.GetStats<T>();
        public BaseNavigationState(D data, P parameter)
        {
            Parameter = parameter;
            Data = data;
        }
    }
}

