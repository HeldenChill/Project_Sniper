using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Core.Data
{
    using SStats;
    [CreateAssetMenu(fileName = "PlayerStatus", menuName = "Status Data/Character")]
    public class CharacterStats : ScriptableObject
    {
        [SerializeField]
        Stat speed;
        [SerializeField]
        Stat jumpSpeed;
        [SerializeField]
        Stat hp;

        private void OnEnable()
        {
            speed.isDirty = true;
            jumpSpeed.isDirty = true;
            hp.isDirty = true;
        }
        public Stat Speed => speed;
        public Stat JumpSpeed => jumpSpeed;
        public Stat Hp => hp;
    }
}