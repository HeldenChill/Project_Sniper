using Dynamic.WorldInterface.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Core.Character.WorldInterfaceSystem;
using Utilities;

namespace _Game
{
    public class BaseWeapon : MonoBehaviour
    {
        [SerializeField]
        BaseSensor sensor;
        WorldInterfaceData data;
        WorldInterfaceModule module;
        public void Equip (WorldInterfaceModule module, WorldInterfaceData data)
        {
            this.data = data;
            this.module = module;
            this.module.AddSensor(sensor);
        }

        public void Unequip()
        {           
            module.RemoveSensor(sensor);
            data = null;
            module = null;
        }
    }
}