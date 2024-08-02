using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Dynamic.WorldInterface.Data
{
    using Utilities.Core.Character.WorldInterfaceSystem;
    public class ScanSensorData : SensorData
    {
        private GameObject detectedObject;
        private Vector2 hitTargetVector;

        private GameObject attackObject;
        private Vector2 attackObjectVector;
        public GameObject DetectedObject
        {
            get => detectedObject;
            set
            {
                detectedObject = value;
            }
        }
        public Vector2 HitTargetVector
        {
            get => hitTargetVector;
            set
            {
                hitTargetVector = value;
            }
        }
        public GameObject AttackObject
        {
            get => attackObject;
            set
            {
                attackObject = value;
            }
        }
        public Vector2 AttackObjectVector
        {
            get => attackObjectVector;
            set
            {
                attackObjectVector = value;
            }
        }
    }
}