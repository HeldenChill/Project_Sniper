using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Core.Character.NavigationSystem
{
    public abstract class AbstractNavigationModule : AbstractModuleSystem<NavigationData,NavigationParameter>
    { 
        public override void Initialize(NavigationData Data,NavigationParameter Parameter)
        {
            this.Data = Data;
            this.Parameter = Parameter;
        }

        public abstract void StartNavigation();
        public abstract void StopNavigation();
        public virtual void Reset()
        {
            //Reset Data;
        }
    }
}