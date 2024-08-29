namespace _Game.Character{
    using UnityEngine;
    using Utilities.Core.Character.LogicSystem;
    using Utilities.StateMachine;
    public abstract class BaseLogicState<T, D, P, E> : BaseState where T : ScriptableObject
        where D : LogicData
        where P : LogicParameter
        where E : LogicEvent
    {
        protected P Parameter;
        protected D Data;
        protected E Event;
        private T stats;
        public T Stats => stats ??= Parameter.GetStats<T>();
        public BaseLogicState(D data, P parameter, E _event)
        {
            Parameter = parameter;
            Data = data;
            Event = _event;
        }
    }
}