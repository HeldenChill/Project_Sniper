using Unity.VisualScripting;
using UnityEngine;

namespace DesignPattern
{
    public class SimpleSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T _instance;

        public static T Ins
        {
            get
            {
                return _instance;
            }
        }
    }
}
