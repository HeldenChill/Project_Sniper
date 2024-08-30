using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Core
{
    using Utilities.Core.Character;
    using Utilities.Core.Character.WorldInterfaceSystem;
    using Utilities.Core.Character.NavigationSystem;    
    using Utilities.Core.Character.LogicSystem;
    using Utilities.Core.Character.PhysicSystem;
    using Utilities.Core.Data;

    public class BaseCharacter<T, 
        LD, LP, LE,
        ND, NP> : MonoBehaviour where T : CharacterStats
        where LD : LogicData, new()
        where LP : LogicParameter, new()
        where LE : LogicEvent, new()
        where ND : NavigationData, new()
        where NP : NavigationParameter, new()
    {
        [SerializeField]
        protected T Stats;
        [SerializeField]
        protected WorldInterfaceModule WorldInterfaceModule;
        [SerializeField]
        protected AbstractNavigationModule<ND, NP> NavigationModule;
        [SerializeField]
        protected AbstractLogicModule<LD, LP, LE> LogicModule;
        [SerializeField]
        protected AbstractPhysicModule PhysicModule;


        protected CharacterWorldInterfaceSystem WorldInterfaceSystem;
        protected CharacterNavigationSystem<ND, NP> NavigationSystem;
        public CharacterLogicSystem<LD, LP, LE> LogicSystem;
        protected CharacterPhysicSystem PhysicSystem;

        [HideInInspector]
        public CharacterParameterData CharacterData;

        protected virtual void Awake()
        {
            CharacterData = new CharacterParameterData();
            WorldInterfaceSystem = new CharacterWorldInterfaceSystem(WorldInterfaceModule, CharacterData);
            NavigationSystem = new CharacterNavigationSystem<ND, NP>(NavigationModule, CharacterData);
            LogicSystem = new CharacterLogicSystem<LD, LP, LE>(LogicModule, CharacterData);
            PhysicSystem = new CharacterPhysicSystem(PhysicModule, CharacterData);                   
        }
      
        protected virtual void OnEnable()
        {
            #region Update Data Event
            NavigationSystem.ReceiveInformation(WorldInterfaceSystem.Data);
            NavigationSystem.ReceiveInformation(Stats);
            LogicSystem.ReceiveInformation(WorldInterfaceSystem.Data);
            LogicSystem.ReceiveInformation(NavigationSystem.Data);
            LogicSystem.ReceiveInformation(PhysicSystem.Data);
            LogicSystem.ReceiveInformation(Stats);
            #endregion

        }

        protected virtual void OnDisable()
        {}

        protected virtual void Update()
        {
            NavigationSystem.Run();
            LogicSystem.Run();
            PhysicSystem.Run();
        }

        protected virtual void FixedUpdate()
        {
            WorldInterfaceSystem.FixedUpdateData();        
            WorldInterfaceSystem.Run();
            NavigationSystem.FixedUpdateData();
            LogicSystem.FixedUpdateData();
            PhysicSystem.FixedUpdateData();
           
        }
    }
}
