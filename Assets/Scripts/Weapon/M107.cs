using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class M107: Weapon
    {
        
        public override IEnumerator ShootBullets()
        {
            if (player == null)
            {
                player = GameObject.FindObjectOfType<Player>();
            }
            while (player.health > 0)
            {
                yield return new WaitForSeconds(bulletInterval);
                Shoot();
            }
        }
        
        public override void Shoot()
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 10.791f), rotation * Quaternion.Euler(0f, 0f, 0f));
        }
        // Start is called before the first frame update
        public override void Start()
        {
            bulletInterval = 0.7f;
            bulletIntervalBase = bulletInterval;
            base.Start();
        }

        // Update is called once per frame
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            bulletInterval = bulletIntervalBase * bulletIntervalReduceRate;
        }
    }
}
