using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Core.Data
{
    [CreateAssetMenu(fileName = "PlayerStatus", menuName = "Status Data/Character")]
    public class CharacterStats : ScriptableObject
    {
        [SerializeField]
        float speed;
        [SerializeField]
        float jumpSpeed;

        public float Speed => speed;
        public float JumpSpeed => jumpSpeed;
    }
}