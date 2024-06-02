using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utilitys.Core.Character.LogicSystem
{
    using Utilitys.Core.Data;
    using System;
    using Utilitys;
    public class LogicData : AbstractDataSystem<LogicData>
    {
        public int RemainingJump;

        public bool IsEndAbility = false;
        public bool IsDashing = false;
        public bool CanDash = true;
        


        public bool IsInflictEffect = false;
        public bool IsGetDamage = false;
        public bool IsDeflecting = false;
        public bool IsBlocking = false;
        protected override void UpdateDataClone()
        {
            if(Clone == null)
            {
                Clone = CreateInstance(typeof(LogicData)) as LogicData;
            }
            Clone.RemainingJump = RemainingJump;
            Clone.IsEndAbility = IsEndAbility;
            Clone.IsDashing = IsDashing;
            Clone.CanDash = CanDash;
            Clone.IsInflictEffect = IsInflictEffect;
            Clone.IsGetDamage = IsGetDamage;           
        }

        

    }
}