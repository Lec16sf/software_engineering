using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class Stretcher: MonoBehaviour
    {
        public float amplitude = 0.0001f;
        public float frequency = 1f;
        public float activationDistance = 30f;
        public Quaternion rotation = Quaternion.identity;
        public bool isShooting = false;
        private Vector3 tempPos = new Vector3();
        public Coroutine shootingCoroutine = null;

        public Rigidbody rb;
        public GameObject firePrefab;
        public GameObject fire;
        public Player player;

        public void Start()
        {
            player = GameObject.FindObjectOfType<Player>();
        }

        public void FixedUpdate()
        {
            // tempPos = transform.position;;
            // tempPos.z += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
            // transform.position = new Vector3(transform.position.x, transform.position.x, tempPos.z);
            if(rb.position.z < player.rb.position.z+activationDistance && isShooting == false)
            {
                shootingCoroutine = StartCoroutine(ShootBullets());
                isShooting = true;
            }
            if(player.rb.position.z > rb.position.z && isShooting == true)
            {
                if (shootingCoroutine != null)
                {
                    StopCoroutine(shootingCoroutine);
                    shootingCoroutine = null;
                }
            }
        }

        public IEnumerator ShootBullets()
        {
            if (player == null)
            {
                player = GameObject.FindObjectOfType<Player>();
            }
            while (player.health > 0)
            {
                fire = Instantiate(firePrefab, transform.position + new Vector3(0f, 0f, 0f), rotation);
                yield return new WaitForSeconds(0.8f);
                Destroy(fire);
            }
        }
    }
}
