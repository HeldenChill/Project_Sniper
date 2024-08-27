using _Game.Character;
using _Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace _Game.Character
{
    using Utilities.Core;
    public class Enemy : BaseCharacter<CharacterStats>
    {
        [SerializeField]
        BaseWeapon weapon;
        public BaseWeapon Weapon => weapon;
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