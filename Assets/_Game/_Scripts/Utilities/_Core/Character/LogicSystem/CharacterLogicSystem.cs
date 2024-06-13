using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utilitys.Core.Character.LogicSystem
{
    using WorldInterfaceSystem;
    using NavigationSystem;
    using PhysicSystem;
    using Utilitys.Core.Character;
    using System;

    /// <summary>
    /// Responsibility for updating interaction logic between DynamicObject and the game world
    /// </summary>
    public class CharacterLogicSystem : AbstractCharacterSystem<AbstractModuleSystem<LogicData, LogicParameter>, LogicData, LogicParameter>
    {
        //Initialize
        public LogicEvent Event;
        public CharacterLogicSystem(AbstractLogicModule module, CharacterParameterData characterData)
        {
            Data = new LogicData();
            Parameter = new LogicParameter();
            Event = ScriptableObject.CreateInstance(typeof(LogicEvent)) as LogicEvent;
            Data.CharacterParameterData = characterData;
            module.Initialize(Data, Parameter, Event);
        }

        
        //Support Function
        


        #region ReceiveInformation Functions
        //Need to update this ReceiveInformation
        public void ReceiveInformation(PhysicData Data)
        {

        }
        public void ReceiveInformation(WorldInterfaceData worldInterface)
        {
            
        }

        public void ReceiveInformation(NavigationData navigation)
        {
            
        }       
        public void ReceiveInformation(Type type, string name)
        {
            Parameter.OnAnimationTriggerEvent?.Invoke(type, name);
        }

        public void ReceiveInformation(Type type,AnimationClip clip)
        {
            Parameter.OnReceiveAnimationClipData?.Invoke(type,clip);
        }
        #endregion
    }
}