using UnityEngine;
using Utilities;

namespace _Game
{
    using Dynamic.WorldInterface.Data;
    using Utilities.Core.Character.WorldInterfaceSystem;
    public class BaseWeapon : MonoBehaviour
    {
        [SerializeField]
        BaseSensor sensor;
        [SerializeField]
        GameObject aimEdge1;
        [SerializeField]
        GameObject aimEdge2;

        WorldInterfaceData data;
        WorldInterfaceModule module;

        FanScanSenorData fanScanSensorData;
        public void Equip (WorldInterfaceModule module, WorldInterfaceData data)
        {
            this.data = data;
            this.module = module;
            this.module.AddSensor(sensor);
            fanScanSensorData = data.GetSensorData<FanScanSenorData>();
        }

        public void Unequip()
        {           
            module.RemoveSensor(sensor);
            data = null;
            module = null;
            fanScanSensorData = null;
        }
        private void Update()
        {
            RotateAlongMouse();
            aimEdge1.transform.rotation = Quaternion.Euler(0, 0, fanScanSensorData.Edge1Angle);
            aimEdge2.transform.rotation = Quaternion.Euler(0, 0, fanScanSensorData.Edge2Angle);
        }

        protected void RotateAlongMouse()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)transform.position);

            transform.rotation = MathHelper.GetQuaternion2Vector(Vector2.right, direction);
        }
    }
}