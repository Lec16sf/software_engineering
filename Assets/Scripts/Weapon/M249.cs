using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class M249: Weapon
    {
        damage = 20f;
        bulletInterval = 0.6f;
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
            Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 3.791f), rotation);

            if(bulletNum >= 3)
            {
                Instantiate(bulletPrefab, transform.position + new Vector3(1f, 0f, 3.791f), rotation);

                Instantiate(bulletPrefab, transform.position + new Vector3(-1f, 0f, 3.791f), rotation);
            }

            if(bulletNum >= 5)
            {
                Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0f, 3.791f), rotation);

                Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 0f, 3.791f), rotation);
            }

            if(bulletNum >= 7)
            {
                Instantiate(bulletPrefab, transform.position + new Vector3(0.25f, 0f, 3.791f), rotation);

                Instantiate(bulletPrefab, transform.position + new Vector3(-0.25f, 0f, 3.791f), rotation);
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
