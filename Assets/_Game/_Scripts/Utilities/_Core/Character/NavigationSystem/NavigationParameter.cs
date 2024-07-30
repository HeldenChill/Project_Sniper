
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utilities.Core.Character.NavigationSystem
{
    using Utilities.Core.Character.WorldInterfaceSystem;
    using Utilities.Core.Character.LogicSystem;

    public class NavigationParameter : AbstractParameterSystem
    {
        public IReadOnlyList<RaycastHit2D> WallHit2D;
        public IReadOnlyList<RaycastHit2D> CharacterHit2D;
        public RaycastHit2D TouchingWallPoint;


        private Vector2 dynamicVelocity;


        private bool isGrounded;
        private bool isTouchingWall;
        private int remainingJump;
        private float dynamicSpeed;




        public Vector2 DynamicVelocity { get => dynamicVelocity; }
        public bool IsGrounded { get => isGrounded; }
        public bool IsTouchingWall { get => isTouchingWall; }
        public int RemainingJump { get => remainingJump; }
        public float DynamicSpeed { get => dynamicSpeed; }

        public virtual void UpdateParameter(WorldInterfaceData Data)
        {
            //DEVELOP:Need to Upgrade
            isGrounded = Data.IsGrounded;
            isTouchingWall = Data.IsTouchingWall;
            WallHit2D = Data.WallHit2D;
            CharacterHit2D = Data.CharacterHit2D;
            TouchingWallPoint = Data.TouchingWallPoint;
        }

        public virtual void UpdateParameter(LogicData Data) // Need to implement code
        {
            remainingJump = Data.RemainingJump;
        }

    }
}