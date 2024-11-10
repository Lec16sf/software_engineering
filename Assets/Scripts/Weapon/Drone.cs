using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class Drone: Weapon
    {
        private Enemy target;
        public override IEnumerator ShootBullets()
        {
            yield return new WaitForSeconds(5f);
            target = FindClosestEnemy();
            FaceEnemy();
            while (player.health > 0 && target.health > 0)
            {
                Shoot();
                yield return new WaitForSeconds(bulletInterval);
                target = null;
                while(target == null)
                {
                    target = FindClosestEnemy();
                }
                target = FindClosestEnemy();
                FaceEnemy();
            }
        }
        
        public override void Shoot()
        {
            Instantiate(bulletPrefab, transform.position + 5f * transform.forward, transform.rotation);
        }

        private Enemy FindClosestEnemy()
        {
            Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
            Enemy closestEnemy = null;
            float closestDistance = Mathf.Infinity;

            foreach (Enemy enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.rb.position);
                if (enemy.rb.position.z > transform.position.z && distance < closestDistance && distance > 30f)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }
        
        public void FaceEnemy()
        {
            Vector3 direction = target.rb.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }

        public override void Start()
        {
            bulletInterval = 0.3f;
            damage = 25f;
            bulletIntervalBase = bulletInterval;
            base.Start();
        }

        public override void FixedUpdate()
        {
        }
    }
}
