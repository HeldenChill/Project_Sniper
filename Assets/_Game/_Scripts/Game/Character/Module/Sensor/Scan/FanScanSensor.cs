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
        private float edge1Deta = 0;
        private float edge2Deta = 0;
        private float edge1Angle = 0;
        private float edge2Angle = 0;
        private float middleAngle = 0;
        [Range(0f, 10f)]
        public float angleChangeVal = 2;
        [Range(0f, 10f)]
        [SerializeField]
        protected float dispersion = 0f;

        #endregion

        public FanScanSenorData SensorData
        {
            get; protected set;
        }
        public override void Initialize(WorldInterfaceData Data, WorldInterfaceParameter Parameter)
        {
            base.Initialize(Data, Parameter);
            middleAngle = transform.parent.rotation.eulerAngles.z;
            edge1Angle = viewAngle + middleAngle;
            edge2Angle = -viewAngle + middleAngle;
            edge1Deta = viewAngle;
            edge2Deta = -viewAngle;
            SensorData = new FanScanSenorData();
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
                Gizmos.DrawLine(eyePosition.position, eyePosition.position + (Vector3)(MathHelper.AngleToVector(edge1Angle, Data.CharacterParameterData.IsFaceRight) * viewRange));
                Gizmos.DrawLine(eyePosition.position, eyePosition.position + (Vector3)(MathHelper.AngleToVector(edge2Angle, Data.CharacterParameterData.IsFaceRight) * viewRange));
            }

        }

        public virtual void Observation()
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(eyePosition.position, MathHelper.AngleToVector(edge1Angle, Data.CharacterParameterData.IsFaceRight), viewRange);

            if (Mathf.Abs(edge1Angle) <= dispersion && Mathf.Abs(edge2Angle) <= dispersion)
            {
                angleChangeVal = 0;
                return;
            }
            middleAngle = transform.parent.rotation.eulerAngles.z;
            edge1Deta += -angleChangeVal * Time.deltaTime;
            edge2Deta += angleChangeVal * Time.deltaTime;

            edge1Angle = middleAngle + edge1Deta;
            edge2Angle = middleAngle + edge2Deta;
        }
    }
}