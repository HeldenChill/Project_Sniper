using UnityEngine;
using Utilitys.Core.Character.NavigationSystem;

namespace Utilitys.Core.Character.LogicSystem
{
    using System;

    public class LogicParameter : AbstractParameterSystem
    {
        public Action<Type, string> OnAnimationTriggerEvent;
        public Action<Type, AnimationClip> OnReceiveAnimationClipData;

        protected bool inflictEffectState = false;
        protected bool dash = false;
        protected bool jump = false;
        protected int remainingJump = 1;
        protected bool attack1 = false;
        protected bool attack2 = false;
        protected bool attack3 = false;
        protected bool isGetDamage = false;


        protected Vector2 moveDir = Vector2.zero;

        protected bool isGrounded;
        protected bool isTouchingWall;
        protected bool isTouchingCorner;
    }
}