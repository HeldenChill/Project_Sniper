using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Core;

namespace _Game.Character
{
    public class Player : BaseCharacter<PlayerStats>
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            #region LOGIC MODULE --> PHYSIC MODULE
            LogicSystem.Event._SetVelocity += PhysicModule.SetVelocity;
            LogicSystem.Event._SetVelocityTime += PhysicModule.SetVelocity;
            LogicSystem.Event._SetVelocityFrame += PhysicModule.SetVelocity;

            LogicSystem.Event._SetVelocityX += PhysicModule.SetVelocityX;
            LogicSystem.Event._SetVelocityXTime += PhysicModule.SetVelocityX;
            LogicSystem.Event._SetVelocityXFrame += PhysicModule.SetVelocityX;

            LogicSystem.Event._SetVelocityY += PhysicModule.SetVelocityY;
            LogicSystem.Event._SetVelocityYTime += PhysicModule.SetVelocityY;
            LogicSystem.Event._SetVelocityYFrame += PhysicModule.SetVelocityY;
            #endregion
        }

        protected override void OnDisable()
        {        
            base.OnDisable();
            #region LOGIC MODULE --> PHYSIC MODULE
            LogicSystem.Event._SetVelocityTime -= PhysicModule.SetVelocity;
            LogicSystem.Event._SetVelocityFrame -= PhysicModule.SetVelocity;
            LogicSystem.Event._SetVelocityXTime -= PhysicModule.SetVelocityX;
            LogicSystem.Event._SetVelocityXFrame -= PhysicModule.SetVelocityX;
            LogicSystem.Event._SetVelocityYTime -= PhysicModule.SetVelocityY;
            LogicSystem.Event._SetVelocityYFrame -= PhysicModule.SetVelocityY;
            #endregion
        }
    }
}