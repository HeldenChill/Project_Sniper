using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utilitys.Core.Character.NavigationSystem
{
    using Utilitys.Core.Character;
    using Utilitys.Core.Character.LogicSystem;
    using Utilitys.Core.Character.WorldInterfaceSystem;

    /// <summary>
    /// Responsibility for navigating the Dynamic Object (Player or Agent) 
    /// </summary>
    public class CharacterNavigationSystem : AbstractCharacterSystem<AbstractNavigationModule, NavigationData, NavigationParameter>
    {
        #region System Components
        //NavigationDecision = Core
        public AbstractNavigationModule InputModule { get => module; set => module = value; }
        #endregion
        #region Essential Functions
        protected CharacterNavigationSystem() { }
        //Initialize
        public CharacterNavigationSystem(AbstractNavigationModule inputModule, CharacterParameterData characterData)
        {
            Data = new NavigationData();
            Parameter = new NavigationParameter();
            this.module = inputModule;
            Data.CharacterParameterData = characterData;
            module.Initialize(Data, Parameter);
        }
        #endregion
        #region ReceiveInformation Functions
        public virtual void ReceiveInformation(WorldInterfaceData worldInterface)
        {
            Parameter.UpdateParameter(worldInterface);
        }
        public virtual void ReceiveInformation(LogicData logic)
        {
            Parameter.UpdateParameter(logic);
        }
        #endregion
    }
}