using UnityEngine;
using System.Collections;

namespace Weapon
{
    public class Weapon: MonoBehaviour
    {
        public float bulletInterval = 0.4f;
        public GameObject bulletPrefab;

        IEnumerator ShootBullets()
        {
            while (true)
            {
                yield return new WaitForSeconds(bulletInterval);
                Shoot();
            }
        }
        
        public virtual void Shoot()
        {
            
        }
        // Start is called before the first frame update
        public virtual void Start()
        {
            StartCoroutine(ShootBullets());
        }

        // Update is called once per frame
        public virtual void Update()
        {
            
        }
        public void OnEnable()
        {
            // 每次激活时调用
            StartCoroutine(ShootBullets());
        }

    }
}
