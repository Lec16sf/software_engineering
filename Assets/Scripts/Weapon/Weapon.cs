using UnityEngine;
using System.Collections;

namespace Weapon
{
    public class Weapon: MonoBehaviour
    {
        public float bulletIntervalBase = 0.4f;
        public float bulletInterval = 0.4f;
        public int bulletNum = 1;
        public float damage = 25f;
        public float bulletIntervalReduceRate = 0;
        public Quaternion rotation = Quaternion.identity;
        public GameObject bulletPrefab;
        public Coroutine shootingCoroutine = null;

        public GameManager gameManager;
        public Player player;

        public virtual IEnumerator ShootBullets()
        {
            while (player.health > 0)
            {
                yield return new WaitForSeconds(bulletInterval);
                Shoot();
            }
        }
        
        public virtual void Shoot()
        {
            
        }

        public virtual void Start()
        {
            gameManager  = GameObject.FindObjectOfType<GameManager>();
            player = GameObject.FindObjectOfType<Player>();
            bulletNum = gameManager.bulletNum;
            gameManager.damage = damage;
            bulletIntervalReduceRate = gameManager.bulletIntervalReduceRate;
            if (shootingCoroutine != null)
            {
                StopCoroutine(shootingCoroutine);
            }
            shootingCoroutine = StartCoroutine(ShootBullets());
        }

        // Update is called once per frame
        public virtual void FixedUpdate()
        {
            gameManager.damage = damage;
        }
        
        public void OnEnable()
        {
            if (player == null)
            {
                player = GameObject.FindObjectOfType<Player>();
            }
            if (gameManager == null)
            {
                gameManager = GameObject.FindObjectOfType<GameManager>();
            }
            bulletNum = gameManager.bulletNum;
            gameManager.damage = damage;
            bulletIntervalReduceRate = gameManager.bulletIntervalReduceRate;
            if (shootingCoroutine == null)
            {
                shootingCoroutine = StartCoroutine(ShootBullets());
            }
        }

        public void OnDisable()
        {
            if (shootingCoroutine != null)
            {
                StopCoroutine(shootingCoroutine);
                shootingCoroutine = null;
            }
        }

    }
}
