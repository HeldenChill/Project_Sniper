using UnityEngine;
using Utilities.Core.Character.NavigationSystem;

namespace Utilities.Core.Character.LogicSystem
{
    using System;

    public class LogicParameter : AbstractParameterSystem
    {
        public Action<Type, string> OnAnimationTriggerEvent;
        public Action<Type, AnimationClip> OnReceiveAnimationClipData;
        public NavigationData NavData;
    }
}