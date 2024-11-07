using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class AK47: Weapon
    {
        public override IEnumerator ShootBullets()
        {
            if (player == null)
            {
                player = GameObject.FindObjectOfType<Player>();
            }
            Debug.Log(bulletInterval);
            while (player.health > 0)
            {
                yield return new WaitForSeconds(bulletInterval);
                Shoot();
            }
        }
        
        public override void Shoot()
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 3.791f), rotation);
        }
        
        public override void Start()
        {
            bulletInterval = 0.3f;
            bulletIntervalBase = bulletInterval;
            base.Start();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            bulletInterval = bulletIntervalBase * bulletIntervalReduceRate;
        }
    }
}
