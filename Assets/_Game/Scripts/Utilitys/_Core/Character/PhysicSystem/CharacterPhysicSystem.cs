using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utilitys.Core.Character.PhysicSystem
{
    using System;
    using WorldInterfaceSystem;
    public class CharacterPhysicSystem : AbstractCharacterSystem<AbstractPhysicModule,PhysicData,PhysicParameter>
    {
        #region Attributes
        public AbstractPhysicModule MovementModule { get => module; set => module = value; }
        #endregion
        public CharacterPhysicSystem(AbstractPhysicModule module, CharacterParameterData characterData)
        {
            Data = new PhysicData();
            Parameter = new PhysicParameter();
            Data.CharacterParameterData = characterData;
            this.module = module;
            module.Initialize(Data,Parameter);
        }


        #region Essential Functions
        //Initialize
        #endregion
        #region Executing Physic System Actions
        public void SetVelocityX(float speed, float time)
        {
            module.SetVelocityX(speed, time);
        }
        public void SetVelocityX(float speed, int frame)
        {
            module.SetVelocityX(speed, frame);
        }
        public void SetVelocityY(float speed, float time)
        {
            module.SetVelocityY(speed, time);
        }
        public void SetVelocityY(float speed, int frame)
        {
            module.SetVelocityY(speed, frame);
        }
        public void SetVelocity(Vector2 speed, float time)
        {
            module.SetVelocity(speed, time);
        }
        public void SetVelocity(Vector2 speed, int frame)
        {
            module.SetVelocity(speed, frame);
        }
        public void DisableGravity()
        {
            module.SetVelocityY(0);
            module.SetGravityScale(0);
        }

        public void EnableGravity()
        {
            module.SetGravityScale(module.OriginaGravitylScale);
        }

        public void IgnoreCollision(bool value, float time = -1)
        {
            module.IgnoreCollision(value, time);
        }
        public void SetTransformPosition(Vector3 position)
        {
            Data.CharacterParameterData.CharacterTransform.position = position;
        }

        public void AddTransformPosition(Vector3 position)
        {
            Data.CharacterParameterData.CharacterTransform.position += position;
        }
        #endregion
    }
}