using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dynamic.WorldInterface.Sensor
{
    using Dynamic.WorldInterface.Data;
    using Unity.VisualScripting;
    using Utilities.Core.Character.WorldInterfaceSystem;
    public class DetectGroundEdgeSensor : BaseSensor
    {
        [SerializeField]
        float checkLength;
        [SerializeField]
        protected Transform leftCheckPointPos;
        [SerializeField]
        protected Transform rightCheckPointPos;

        [SerializeField] protected bool rightEdgeDetected;
        [SerializeField] protected bool leftEdgeDetected;
        public DetectGroundEdgeData SensorData
        {
            get;
            protected set;
        }
        public override void Initialize(WorldInterfaceData Data, WorldInterfaceParameter Parameter)
        {
            base.Initialize(Data, Parameter);
            SensorData = new DetectGroundEdgeData();
            Data.SensorDatas.Add(SensorData);
        }

        public override void UpdateState()
        {
            SensorData.RightEdgeDetected = Physics2D.Raycast(rightCheckPointPos.position, rightCheckPointPos.right, checkLength, layer);
            SensorData.LeftEdgeDetected = Physics2D.Raycast(leftCheckPointPos.position, leftCheckPointPos.right, checkLength, layer);
            rightEdgeDetected = SensorData.RightEdgeDetected;
            leftEdgeDetected = SensorData.LeftEdgeDetected;
        }

        protected override void OnDrawGizmos()
        {
            Gizmos.DrawLine(rightCheckPointPos.position, rightCheckPointPos.position + rightCheckPointPos.right * checkLength);
            Gizmos.DrawLine(leftCheckPointPos.position, leftCheckPointPos.position + leftCheckPointPos.right * checkLength);
        }
    }
}