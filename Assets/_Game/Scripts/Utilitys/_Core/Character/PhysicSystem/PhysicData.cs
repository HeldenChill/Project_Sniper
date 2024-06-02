using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilitys.Core.Character.PhysicSystem
{
    public class PhysicData : AbstractDataSystem<PhysicData>
    {
        protected override void UpdateDataClone()
        {
            if(Clone == null)
            {
                Clone = CreateInstance(typeof(PhysicData)) as PhysicData;
            }
        }
    }
}