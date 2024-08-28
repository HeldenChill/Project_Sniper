using Dynamic.WorldInterface.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Core.Character.WorldInterfaceSystem;

namespace _Game
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        protected WorldInterfaceData data;
        protected WorldInterfaceModule module;

        public abstract void Fire();
        public virtual void Equip(WorldInterfaceModule module, WorldInterfaceData data)
        {
            this.data = data;
            this.module = module;
            
        }

        public virtual void Unequip()
        {
            data = null;
            module = null;           
        }
    }
}