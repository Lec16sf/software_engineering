using UnityEngine;
using System.Collections;

public class Player : Character
{
    public float forwardForce = 500f;
    public float sidewaysForce = 20f;
    public GameObject bulletPrefab; // 子弹预制件
    public float bulletInterval = 0.5f; // 子弹生成间隔

    public override void Start()
    {
        base.Start();
        // StartCoroutine(ShootBullets());
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        rb.AddForce(0, 0, forwardForce*Time.deltaTime);
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Enemy")
        {
            this.ChangeHealth(collisionInfo.collider.GetComponent<Enemy>().health);
        }
    }

    public override void Die()
    {
        forwardForce = 0;
        FindObjectOfType<GameManager>().EndGame();
    }

    // 协程定时生成子弹
    // IEnumerator ShootBullets()
    // {
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(bulletInterval);
    //         Shoot();
    //     }
    // }

    // // 生成子弹的方法
    // void Shoot()
    // {
    //     Quaternion rotation = transform.rotation;
    //     rotation.x = 0;
    //     rotation.y = 0;
    //     // Instantiate(bulletPrefab, transform.position + new Vector3(0.2f, 1.4f, 1f), transform.rotation);
    //     Instantiate(bulletPrefab, transform.position + new Vector3(0.1999995f, 1.2f, 1.091f), transform.rotation);
    // }

}
