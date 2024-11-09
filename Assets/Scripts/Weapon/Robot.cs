using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class Robot: MonoBehaviour
    {
        public float bulletInterval = 0.4f;
        public float damage = 25f;
        public int bulletNum = 1;
        public float activationDistance = 20f;
        public bool isShooting = false;
        public GameObject firePrefab;
        public GameObject bulletPrefab;
        public Coroutine shootingCoroutine = null;
        public Quaternion rotation = Quaternion.identity;
        private Enemy robot;
        public Player player;
        public Rigidbody rb;
        public IEnumerator ShootBullets()
        {
            if (robot == null)
            {
                robot = GetComponentInParent<Enemy>();
            }
            while (robot.health > 0)
            {
                yield return new WaitForSeconds(2f);
                int shootMethod = Random.Range(1, 7);
                int times;
                Debug.Log("shootMethod: " + shootMethod);
                switch (shootMethod)
                {
                    case 1:
                        times = Random.Range(3, 7);
                        for (int i = 0; i < times; i++)
                        {
                            ShootMethod1();
                            yield return new WaitForSeconds(0.2f);
                        }
                        break;
                    case 2:
                        times = Random.Range(3, 7);
                        for (int i = 0; i < times; i++)
                        {
                            ShootMethod2();
                            yield return new WaitForSeconds(0.2f);
                        }
                        break;
                    case 3:
                        times = Random.Range(3, 7);
                        for (int i = 0; i < times; i++)
                        {
                            ShootMethod3();
                            yield return new WaitForSeconds(0.2f);
                        }
                        break;
                    case 4:
                        times = Random.Range(3, 7);
                        for (int i = 0; i < times; i++)
                        {
                            ShootMethod4();
                            yield return new WaitForSeconds(0.2f);
                        }
                        break;
                    case 5:
                        times = Random.Range(1, 3);
                        for (int i = 0; i < times; i++)
                        {
                            ShootMethod5();
                            yield return new WaitForSeconds(0.5f);
                        }
                        break;
                    case 6:
                        times = Random.Range(3, 7);
                        for (int i = 0; i < times; i++)
                        {
                            ShootMethod6();
                            yield return new WaitForSeconds(0.5f);
                        }
                        break;
                }
            }
        }
        
        public void Shoot()
        {

        }
        
        public void ShootMethod1()
        {
            Instantiate(firePrefab, transform.position + new Vector3(-3f, 1.5f, -3.791f), rotation);
            Instantiate(firePrefab, transform.position + new Vector3(3f, 1.5f, -3.791f), rotation);
        }

        public void ShootMethod2()
        {
            Instantiate(firePrefab, transform.position + new Vector3(0f, 1.5f, -3.791f), rotation);
        }

        public void ShootMethod3()
        {
            Instantiate(firePrefab, transform.position + new Vector3(0f, 1.5f, -3.791f), rotation);
            Instantiate(firePrefab, transform.position + new Vector3(3f, 1.5f, -3.791f), rotation);
        }

        public void ShootMethod4()
        {
            Instantiate(firePrefab, transform.position + new Vector3(0f, 1.5f, -3.791f), rotation);
            Instantiate(firePrefab, transform.position + new Vector3(-3f, 1.5f, -3.791f), rotation);
        }

        public void ShootMethod5()
        {
            bulletNum = Random.Range(1, 7);
            Instantiate(bulletPrefab, transform.position + new Vector3(0f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, 0f, 0f));

            if(bulletNum >= 3)
            {
                Instantiate(bulletPrefab, transform.position + new Vector3(0.25f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, -7.5f, 0f));

                Instantiate(bulletPrefab, transform.position + new Vector3(-0.25f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, 7.5f, 0f));
            }

            if(bulletNum >= 5)
            {
                Instantiate(bulletPrefab, transform.position + new Vector3(1f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, -30f, 0f));

                Instantiate(bulletPrefab, transform.position + new Vector3(-1f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, 30f, 0f));
            }

            if(bulletNum >= 7)
            {
                Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, -15f, 0f));

                Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, 15f, 0f));
            }
        }

        public void ShootMethod6()
        {
               
            if(Random.Range(0f, 1f) < 0.6f)
                Instantiate(bulletPrefab, transform.position + new Vector3(0f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, 0f, 0f));

            if(Random.Range(0f, 1f) < 0.6f)
                Instantiate(bulletPrefab, transform.position + new Vector3(0.25f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, -7.5f, 0f));
            if(Random.Range(0f, 1f) < 0.6f)
                Instantiate(bulletPrefab, transform.position + new Vector3(-0.25f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, 7.5f, 0f));

            if(Random.Range(0f, 1f) < 0.6f)
                Instantiate(bulletPrefab, transform.position + new Vector3(1f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, -30f, 0f));

            if(Random.Range(0f, 1f) < 0.6f)
                Instantiate(bulletPrefab, transform.position + new Vector3(-1f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, 30f, 0f));

            if(Random.Range(0f, 1f) < 0.6f)
                Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, -15f, 0f));

            if(Random.Range(0f, 1f) < 0.6f)
                Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 1.5f, -3.791f), rotation * Quaternion.Euler(0f, 15f, 0f));
        }
        public void Start()
        {
            robot = GetComponentInParent<Enemy>();
            player = GameObject.FindObjectOfType<Player>();
        }

        public void FixedUpdate()
        {
            if(rb.position.z < player.rb.position.z+activationDistance && isShooting == false)
            {
                Debug.Log("start shooting");
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
    }
}
