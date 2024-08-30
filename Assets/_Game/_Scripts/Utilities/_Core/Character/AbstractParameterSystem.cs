using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using Utilities.Core.Data;

namespace Utilities.Core.Character
{
    public class AbstractParameterSystem
    {
        protected CharacterStats stats;

        public void SetStats<T>(T value) where T : CharacterStats
        {
            stats = value;
        }
        public T GetStats<T>() where T : CharacterStats
        {
            return (T)stats;
        }
    }
}