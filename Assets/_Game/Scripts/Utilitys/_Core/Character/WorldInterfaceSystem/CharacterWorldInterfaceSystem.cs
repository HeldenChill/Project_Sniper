using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utilitys.Core.Character.WorldInterfaceSystem
{
    using Utilitys.Core.Character;
    /// <summary>
    /// Responsible for updating knowledgement about the game world for DynamicObject
    /// </summary>
    public class CharacterWorldInterfaceSystem : AbstractCharacterSystem<WorldInterfaceModule, WorldInterfaceData, WorldInterfaceParameter>
    {
        #region Essential Functions
        protected CharacterWorldInterfaceSystem() { }
        public CharacterWorldInterfaceSystem(WorldInterfaceModule module, CharacterParameterData characterData)
        {
            this.module = module;
            Data = ScriptableObject.CreateInstance(typeof(WorldInterfaceData)) as WorldInterfaceData;
            Parameter = ScriptableObject.CreateInstance(typeof(WorldInterfaceParameter)) as WorldInterfaceParameter;
            Data.CharacterParameterData = characterData;
            module.Initialize(Data, Parameter);
        }
        #endregion
    }
}