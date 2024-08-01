using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Character
{
    using Utilities.Core.Character.LogicSystem;
    using System;

    public class PlayerLogicModule : AbstractLogicModule
    {
        public override void UpdateData()
        {
            if (Parameter.NavData.Jump.Value)
            {
                Event.SetVelocityY(10);
            }
        }
        public override void FixedUpdateData()
        {
            Event.SetVelocityX(Math.Sign(Parameter.NavData.MoveDirection.x) 
                * Parameter.GetStats<PlayerStatus>().Speed);
        }
    }
}