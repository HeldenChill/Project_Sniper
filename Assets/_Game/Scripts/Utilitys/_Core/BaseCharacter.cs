using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilitys.Core
{
    using Utilitys.Core.Character;
    using Utilitys.Core.Character.WorldInterfaceSystem;
    using Utilitys.Core.Character.NavigationSystem;    
    using Utilitys.Core.Character.LogicSystem;
    using Utilitys.Core.Character.PhysicSystem;

    public class BaseCharacter : MonoBehaviour
    {
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
            CharacterData = ScriptableObject.CreateInstance(typeof(CharacterParameterData)) as CharacterParameterData;
            WorldInterfaceSystem = new CharacterWorldInterfaceSystem(WorldInterfaceModule, CharacterData);
            NavigationSystem = new CharacterNavigationSystem(NavigationModule, CharacterData);
            LogicSystem = new CharacterLogicSystem(LogicModule, CharacterData);
            PhysicSystem = new CharacterPhysicSystem(PhysicModule, CharacterData);                   
        }
      
        protected virtual void OnEnable()
        {
            #region Update Data Event
            WorldInterfaceSystem.OnUpdateData += NavigationSystem.ReceiveInformation;
            WorldInterfaceSystem.OnUpdateData += LogicSystem.ReceiveInformation;

            NavigationSystem.OnUpdateData += LogicSystem.ReceiveInformation;
            PhysicSystem.OnUpdateData += LogicSystem.ReceiveInformation;

            #endregion

        }

        protected virtual void OnDisable()
        {
            #region Update Data Event
            WorldInterfaceSystem.OnUpdateData -= NavigationSystem.ReceiveInformation;
            WorldInterfaceSystem.OnUpdateData -= LogicSystem.ReceiveInformation;

            NavigationSystem.OnUpdateData -= LogicSystem.ReceiveInformation;
            PhysicSystem.OnUpdateData -= LogicSystem.ReceiveInformation;
            #endregion
        }

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
