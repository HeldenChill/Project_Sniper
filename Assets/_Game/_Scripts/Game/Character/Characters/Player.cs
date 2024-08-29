using System.Collections;
using System.Collections.Generic;


namespace _Game.Character
{
    using UnityEngine;
    using Utilities.Core;
    using Utilities.Core.Character.LogicSystem;
    using Utilities.Core.Character.NavigationSystem;
    public class Player : BaseCharacter<CharacterStats, 
        LogicData, LogicParameter, LogicEvent,
        NavigationData, NavigationParameter>
    {
        [SerializeField]
        PlayerWeapon weapon;
        public PlayerWeapon Weapon => weapon;
        protected override void Awake()
        {
            base.Awake();
            weapon.Equip(WorldInterfaceModule, WorldInterfaceSystem.Data);
        }
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
            LogicSystem.Event._OnFire += Weapon.Fire;
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
            LogicSystem.Event._OnFire -= Weapon.Fire;
            #endregion
        }
    }
}