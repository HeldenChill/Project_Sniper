using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Character
{
    using UnityEngine.InputSystem;
    using Utilities;
    using Utilities.Core.Character.NavigationSystem;

    public class InputModule : AbstractNavigationModule
    {

        private void Awake()
        {
            PlayerInputActions playerInputActions = new PlayerInputActions();
            playerInputActions.Player.Enable();
            playerInputActions.Player.Jump.performed += OnJump;
        }
        public override void StartNavigation()
        {

        }

        public override void StopNavigation()
        {

        }

        public override void UpdateData()
        {

        }

        protected void OnJump(InputAction.CallbackContext callback)
        {
            DevLog.Log(DevId.Hung, "Jump");
            Data.Jump.Value = true;
        }
    }
}