using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilitys.Core.Character
{
    using System;
    public abstract class AbstractDataSystem<D> : ScriptableObject
    {
        protected D Clone;
        public CharacterParameterData CharacterParameterData;
        public D OnUpdateData()
        {
            UpdateDataClone();
            return Clone;
        }

        protected abstract void UpdateDataClone();
    }
}
