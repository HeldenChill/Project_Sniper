using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Character
{
    using Utilities.Core.Data;
    [CreateAssetMenu(fileName = "EnemyStatus", menuName = "Status Data/Enemy")]
    public class EnemyStats : CharacterStats
    {
        [Serializable]
        public class HiddenStats
        {
            [SerializeField]
            float maxTimePatrol;
            [SerializeField]
            float minTimePatrol;
            [SerializeField]
            float maxTimeIdle;
            [SerializeField]
            float minTimeIdle;

            public float MaxTimePatrol => maxTimePatrol;
            public float MinTimePatrol => minTimeIdle;
            public float MaxTimeIdle => maxTimeIdle;
            public float MinTimeIdle => minTimeIdle;
        }

        [SerializeField]
        HiddenStats hidden;
        public HiddenStats Hidden => hidden;
    }
}