
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utilities.Core.Character.NavigationSystem
{
    using Utilities.Core.Character.WorldInterfaceSystem;
    using Utilities.Core.Character.LogicSystem;

    public class NavigationParameter : AbstractParameterSystem
    {
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