using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game
{
    using DesignPattern;
    public class BaseBullet : GameUnit
    {
        [SerializeField]
        Rigidbody2D rb;
        [SerializeField]
        float speed;
        public void Shot()
        {
            rb.velocity = Tf.right * speed;
        }
    }
}