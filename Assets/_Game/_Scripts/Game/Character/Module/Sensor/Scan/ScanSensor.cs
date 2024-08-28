using Dynamic.WorldInterface.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dynamic.WorldInterface.Sensor
{
    using Utilities;
    using Utilities.Core.Character.WorldInterfaceSystem;
    public class ScanSensor : BaseSensor
    {        
        [SerializeField] protected Transform eyePosition;
        [SerializeField] protected float viewRange;
        [SerializeField] protected float viewAngle;

        #region Variable
        private float currentAngle = 0;
        [Range(0f, 100f)]
        public float angleChangeVal = 2;
        #endregion

        public ScanSensorData SensorData
        {
            get; protected set;
        }
        public override void Initialize(WorldInterfaceData Data, WorldInterfaceParameter Parameter)
        {
            base.Initialize(Data, Parameter);
            SensorData = new ScanSensorData();
            Data.SensorDatas.Add(SensorData);
        }
        public override void UpdateState()
        {
            Observation();
        }

        protected override void OnDrawGizmos()
        {
            if (Data != null && eyePosition != null)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(eyePosition.position, eyePosition.position + (Vector3)(MathHelper.AngleToVector(currentAngle, Data.CharacterParameterData.IsFaceRight) * viewRange));
            }

        }

        public virtual void Observation()
        {
            if (currentAngle >= viewAngle || currentAngle <= -viewAngle)
            {
                angleChangeVal = -angleChangeVal;
            }

            RaycastHit2D hit;
            hit = Physics2D.Raycast(eyePosition.position, MathHelper.AngleToVector(currentAngle, Data.CharacterParameterData.IsFaceRight), viewRange);
            currentAngle += angleChangeVal * Time.deltaTime;


            if (!hit)
            {
                SensorData.HitTargetVector = default;
                SensorData.DetectedObject = null;
            }
            else
            {
                SensorData.DetectedObject = hit.collider.gameObject;
                SensorData.HitTargetVector = (hit.point - (Vector2)eyePosition.position);
                if (SensorData.DetectedObject.layer == LayerMask.NameToLayer("Character"))
                {
                    SensorData.AttackObjectVector = (hit.point - (Vector2)eyePosition.position);
                    SensorData.AttackObject = hit.collider.gameObject;
                }
                else
                {
                    //ArcherState.attackTargetVector = default;
                    SensorData.AttackObject = default;
                }
            }
        }
    }
}