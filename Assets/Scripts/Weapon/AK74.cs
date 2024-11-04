using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class AK47: Weapon
    {

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
            Quaternion rotation = transform.rotation;
            rotation.x = 0;
            rotation.y = 0;
            Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 1.091f), transform.rotation);
        }
        // Start is called before the first frame update
        public override void Start()
        {
            base.Start();
            bulletInterval = 0.4f;
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
        }
    }
}
