using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class Bennelli_M4: Weapon
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
            // 指定子弹的运动方向
            GameObject bullet1 = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 1.091f), transform.rotation* Quaternion.Euler(0f, 180f, 0f));

            GameObject bullet2 = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 1.091f), transform.rotation * Quaternion.Euler(0f, 150f, 0f));

            // GameObject bullet3 = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 1.091f), transform.rotation * Quaternion.Euler(0f, 30f, 0f));
            // bullet3.GetComponent<Bullet>().direction = new Vector3(0f, 30f, 0f);

            // GameObject bullet4 = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 1.091f), transform.rotation * Quaternion.Euler(0f, 60f, 0f));
            // bullet4.GetComponent<Bullet>().direction = new Vector3(0f, 60f, 0f);

            // GameObject bullet5 = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 1.091f), transform.rotation * Quaternion.Euler(0f, -60f, 0f));
            // bullet5.GetComponent<Bullet>().direction = new Vector3(0f, -60f, 0f);
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
