using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utilities.Core.Character.LogicSystem
{
    using Utilities.Core.Data;
    using System;
    using Utilities;
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
    }
}