using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Character
{
    using Utilities.Core.Character.LogicSystem;

    public class PlayerLogicModule : AbstractLogicModule
    {
        public override void UpdateData()
        {
            if (Parameter.NavData.Jump.Value)
            {
                Event.SetVelocityY(10);
            }
        }    
    }
}