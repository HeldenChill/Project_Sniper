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

    public class BaseCharacter<T> : MonoBehaviour where T : ScriptableObject
    {
        [SerializeField]
        protected T Stats;
        [SerializeField]
        protected WorldInterfaceModule WorldInterfaceModule;
        [SerializeField]
        protected AbstractNavigationModule NavigationModule;
        [SerializeField]
        protected AbstractLogicModule LogicModule;
        [SerializeField]
        protected AbstractPhysicModule PhysicModule;


        protected CharacterWorldInterfaceSystem WorldInterfaceSystem;
        protected CharacterNavigationSystem NavigationSystem;
        public CharacterLogicSystem LogicSystem;
        protected CharacterPhysicSystem PhysicSystem;

        [HideInInspector]
        public CharacterParameterData CharacterData;

        [HideInInspector]
        protected virtual void Awake()
        {
            CharacterData = new CharacterParameterData();
            WorldInterfaceSystem = new CharacterWorldInterfaceSystem(WorldInterfaceModule, CharacterData);
            NavigationSystem = new CharacterNavigationSystem(NavigationModule, CharacterData);
            LogicSystem = new CharacterLogicSystem(LogicModule, CharacterData);
            PhysicSystem = new CharacterPhysicSystem(PhysicModule, CharacterData);                   
        }
      
        protected virtual void OnEnable()
        {
            #region Update Data Event
            NavigationSystem.ReceiveInformation(WorldInterfaceSystem.Data);
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
