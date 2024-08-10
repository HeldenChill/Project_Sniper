using Dynamic.WorldInterface.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Core.Character.WorldInterfaceSystem;
using Utilities;
namespace Dynamic.WorldInterface.Sensor
{
    public class FanScanSensor : BaseSensor
    {
        [SerializeField] protected Transform eyePosition;
        [SerializeField] protected float viewRange;
        [SerializeField] protected float viewAngle;

        #region Variable
        private float edge1Angle = 0;
        private float edge2Angle = 0;
        [Range(0f, 10f)]
        public float angleChangeVal = 2;
        [Range(0f, 10f)]
        [SerializeField]
        protected float dispersion = 0f;

        #endregion

        public ScanSensorData SensorData
        {
            get; protected set;
        }
        public override void Initialize(WorldInterfaceData Data, WorldInterfaceParameter Parameter)
        {
            base.Initialize(Data, Parameter);
            edge1Angle = viewAngle;
            edge2Angle = -viewAngle;
            SensorData = new ScanSensorData();
            //Data.SensorDatas.Add(SensorData);
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
                Gizmos.DrawLine(eyePosition.position, eyePosition.position + (Vector3)(MathHelper.AngleToVector(edge1Angle, Data.CharacterParameterData.IsFaceRight) * viewRange));
                Gizmos.DrawLine(eyePosition.position, eyePosition.position + (Vector3)(MathHelper.AngleToVector(edge2Angle, Data.CharacterParameterData.IsFaceRight) * viewRange));
            }

        }

        public virtual void Observation()
        {
            if (Mathf.Abs(edge1Angle) <= dispersion && Mathf.Abs(edge2Angle) <= dispersion)
            {
                angleChangeVal = 0;
            }

            RaycastHit2D hit;
            hit = Physics2D.Raycast(eyePosition.position, MathHelper.AngleToVector(edge1Angle, Data.CharacterParameterData.IsFaceRight), viewRange);
            edge1Angle += -angleChangeVal * Time.deltaTime;
            edge2Angle += angleChangeVal * Time.deltaTime;


            if (!hit)
            {
                SensorData.HitTargetVector = default;
                SensorData.DetectedObject = null;
            }
            else
            {
                SensorData.DetectedObject = hit.collider.gameObject;
                SensorData.HitTargetVector = (hit.point - (Vector2)eyePosition.position);
                if (SensorData.DetectedObject.layer == LayerMask.NameToLayer("Fighter"))
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