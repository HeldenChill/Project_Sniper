using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utilities.Core.Character.NavigationSystem
{
    using Utilities.Core.Character;
    using Utilities.Core.Character.LogicSystem;
    using Utilities.Core.Character.WorldInterfaceSystem;

    /// <summary>
    /// Responsibility for navigating the Dynamic Object (Player or Agent) 
    /// </summary>
    public class CharacterNavigationSystem : AbstractCharacterSystem<AbstractNavigationModule, NavigationData, NavigationParameter>
    {
        #region System Components
        //NavigationDecision = Core
        public AbstractNavigationModule Module { get => module; set => module = value; }
        #endregion
        #region Essential Functions
        protected CharacterNavigationSystem() { }
        //Initialize
        public CharacterNavigationSystem(AbstractNavigationModule inputModule, CharacterParameterData characterData)
        {
            data = new NavigationData();
            Parameter = new NavigationParameter();
            this.module = inputModule;
            data.CharacterParameterData = characterData;
            module.Initialize(data, Parameter);
        }
        #endregion

        //DEV: Need Change By Generic Class
        public void SetNavigationData(NavigationData data)
        {
            this.data = data;
            module.Initialize(data, Parameter);
        }
        #region ReceiveInformation Functions
        public virtual void ReceiveInformation(WorldInterfaceData worldInterface)
        {
            Parameter.WIData = worldInterface;
        }
        #endregion
    }
}