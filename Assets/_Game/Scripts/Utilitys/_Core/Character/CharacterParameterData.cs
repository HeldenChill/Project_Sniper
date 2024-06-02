using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
namespace Utilitys.Core.Character
{
    public class CharacterParameterData : ScriptableObject
    {
        private Transform characterTransform;
        private bool isFaceRight = true;
        private Vector2 rbVelocity;
       
        public void Initialize(Transform characterTransform)
        {
            this.characterTransform = characterTransform;
        }
        public bool IsFaceRight { 
            get => isFaceRight; 
        }

        public Vector2 FaceDirection
        {
            get
            {
                if (isFaceRight)
                {
                    return Vector2.right;
                }
                else
                {
                    return Vector2.left;
                }
            }

            set
            {
                if(value.x > 0)
                {
                    isFaceRight = true;
                }
                else
                {
                    isFaceRight = false;
                }
            }
        }
        public Vector2 RbVelocity { 
            get => rbVelocity;
            set
            {
                if((rbVelocity - value).magnitude > 0.1f)
                {
                    rbVelocity = value;
                }
                    
            }
        }

        public Transform CharacterTransform { 
            get => characterTransform;

            set 
            { 
                characterTransform = value;
            }
        }
    }
}