namespace _Game.Character{
    using UnityEngine;
    using Utilities.Core.Character.LogicSystem;
    using Utilities.StateMachine;
    public abstract class BaseLogicState<T> : BaseState where T : ScriptableObject
    {
        protected LogicParameter Parameter;
        protected LogicData Data;
        protected LogicEvent Event;
        private T stats;
        public T Stats => stats ??= Parameter.GetStats<T>();
        public BaseLogicState(LogicParameter parameter, LogicData data, LogicEvent _event)
        {
            Parameter = parameter;
            Data = data;
            Event = _event;
        }
    }
}