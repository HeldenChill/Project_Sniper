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
            Data = new WorldInterfaceData();
            Parameter = new WorldInterfaceParameter();
            Data.CharacterParameterData = characterData;
            module.Initialize(Data, Parameter);
        }
        #endregion
    }
}