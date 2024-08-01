using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Character
{
    [CreateAssetMenu(fileName = "PlayerStatus", menuName = "Status Data/Player")]
    public class PlayerStatus : ScriptableObject
    {
        [SerializeField]
        float speed;

        public float Speed => speed;
    }
}