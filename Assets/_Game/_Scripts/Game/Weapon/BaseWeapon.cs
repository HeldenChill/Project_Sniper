using UnityEngine;
using Utilities;
using Utilities.Core.Character.WorldInterfaceSystem;

namespace _Game
{
    public class BaseWeapon : MonoBehaviour
    {
        [SerializeField]
        BaseSensor sensor;
        WorldInterfaceData data;
        WorldInterfaceModule module;
        public void Equip (WorldInterfaceModule module, WorldInterfaceData data)
        {
            this.data = data;
            this.module = module;
            this.module.AddSensor(sensor);
        }

        public void Unequip()
        {           
            module.RemoveSensor(sensor);
            data = null;
            module = null;
        }
        private void Update()
        {
            RotateAlongMouse();
        }

        protected void RotateAlongMouse()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)transform.position);

            transform.rotation = MathHelper.GetQuaternion2Vector(Vector2.right, direction);
        }
    }
}