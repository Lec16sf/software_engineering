using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class Bennelli_M4: Weapon
    {
        damage = 15f;
        bulletInterval = 0.5f;

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

            if(bulletNum >= 3)
            {
                Instantiate(bulletPrefab, transform.position + new Vector3(0.25f, 0f, 3.791f), rotation * Quaternion.Euler(0f, 7.5f, 0f));

                Instantiate(bulletPrefab, transform.position + new Vector3(-0.25f, 0f, 3.791f), rotation * Quaternion.Euler(0f, -7.5f, 0f));
            }

            if(bulletNum >= 5)
            {
                Instantiate(bulletPrefab, transform.position + new Vector3(1f, 0f, 3.791f), rotation * Quaternion.Euler(0f, 30f, 0f));

                Instantiate(bulletPrefab, transform.position + new Vector3(-1f, 0f, 3.791f), rotation * Quaternion.Euler(0f, -30f, 0f));
            }

            if(bulletNum >= 7)
            {
                Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0f, 3.791f), rotation * Quaternion.Euler(0f, 15f, 0f));

                Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 0f, 3.791f), rotation * Quaternion.Euler(0f, -15f, 0f));
            }
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
