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
        protected object source;
        [SerializeField]
        protected float damage;

        public abstract void Fire();
        public virtual void Equip(WorldInterfaceModule module, WorldInterfaceData data, object source)
        {
            this.data = data;
            this.module = module;
            this.source = source;
        }

        public virtual void Unequip()
        {
            data = null;
            module = null;           
        }
    }
}