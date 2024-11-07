using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class M4_8: Weapon
    {
        damage = 20f;
        bulletInterval = 0.15f;
        IEnumerator ShootBullets()
        {
            while (true)
            {
                yield return new WaitForSeconds(bulletInterval);
                Shoot();
            }
        }
        
        public override void Shoot()
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 3.791f), rotation * Quaternion.Euler(0f, 0f, 0f));
        }
        // Start is called before the first frame update
        public override void Start()
        {
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
