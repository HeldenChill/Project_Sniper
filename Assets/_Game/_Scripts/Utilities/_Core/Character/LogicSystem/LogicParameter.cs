using UnityEngine;
using Utilities.Core.Character.NavigationSystem;

namespace Utilities.Core.Character.LogicSystem
{
    using System;
    using Utilities.Core.Character.WorldInterfaceSystem;

    public class LogicParameter : AbstractParameterSystem
    {
        public Action<Type, string> OnAnimationTriggerEvent;
        public Action<Type, AnimationClip> OnReceiveAnimationClipData;
        public NavigationData NavData;
        public WorldInterfaceData WIData;

        private ScriptableObject stats;
        public void SetStats<T>(T value) where T : ScriptableObject
        {
            stats = value;
        }
        public T GetStats<T>() where T : ScriptableObject
        {
            return (T)stats;
        }
    }
}