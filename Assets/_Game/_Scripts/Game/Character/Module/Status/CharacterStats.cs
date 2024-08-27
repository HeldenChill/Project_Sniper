using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Character
{
    [CreateAssetMenu(fileName = "PlayerStatus", menuName = "Status Data/Player")]
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