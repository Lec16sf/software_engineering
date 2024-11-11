using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class DroneMove:MonoBehaviour
    {
        // 实现Drone的上下浮动动画同时跟随玩家
        public float amplitude = 0.1f;
        public float frequency = 1f;
        private Vector3 posOffset = new Vector3();
        private Vector3 tempPos = new Vector3();
        private Player player;

        public void Start()
        {
            posOffset = transform.position;
            player = GameObject.FindObjectOfType<Player>();
        }

        public void FixedUpdate()
        {
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
            transform.position = new Vector3(player.transform.position.x + 0.8f, tempPos.y, player.transform.position.z);
        }

    }
}
