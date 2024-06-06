using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilitys.Core.Character.NavigationSystem
{
    using System;

    public class NavigationData : AbstractDataSystem<NavigationData>
    {
        private Vector2 velocityControl = Vector2.zero;

        public bool Attack1 = false;
        public bool Attack2 = false;
        public bool Attack3 = false;
        public bool Jump = false;
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

        protected override void UpdateDataClone()
        {
            if(Clone == null)
            {
                Clone = new NavigationData();
            }
            Clone.Attack1 = Attack1;
            Clone.Attack2 = Attack2;
            Clone.Attack3 = Attack3;
            Clone.velocityControl = velocityControl;
            Clone.Jump = Jump;
            Clone.Dash = Dash;
            Clone.EquipItem = EquipItem;
            ResetData();
        }

        protected void ResetData()
        {
            Attack1 = false;
            Attack2 = false;
            Attack3 = false;
            Jump = false;
            Dash = false;
            EquipItem = false;
        }
    }
}