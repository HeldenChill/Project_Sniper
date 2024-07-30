using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Core.Character.NavigationSystem
{
    using Utilities.Timer;
    public class Trigger
    {
        bool value;
        public bool Value
        {
            get => value;
            set
            {
                this.value = value;
                TimerManager.Ins.WaitForFrame(1, () => this.value = false);
            }
        }
    }
    public class NavigationData : AbstractDataSystem<NavigationData>
    {
        private Vector2 velocityControl = Vector2.zero;

        public bool Attack1 = false;
        public bool Attack2 = false;
        public bool Attack3 = false;
        public Trigger Jump = new Trigger();
        public bool Dash = false;
        public bool EquipItem = false;

        public Vector2 VelocityControl
        {
            get => velocityControl;
            set
            {
                if (velocityControl != value)
                {
                    velocityControl = value;
                }

            }
        }
    }
}