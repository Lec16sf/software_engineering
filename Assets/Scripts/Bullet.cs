using UnityEngine;

public class Bullet : Character
{
    public Rigidbody rb;
    public int finalEndurance = 1; 
    public int endurance = 1; //弹药耐久
    public float speed = 20f;
    public float lifetime = 5f;
    // 运动方向的向量
    public Vector3 direction;

    public override void Start()
    {
        endurance = finalEndurance;
        Destroy(gameObject, lifetime);
    }

    public override void FixedUpdate()
    {
        // 沿着运动方向施加力
        // rb.AddForce(direction * speed * Time.deltaTime, ForceMode.VelocityChange);
        //使得子弹沿着子弹方向运动
        rb.velocity = transform.forward * speed;
        // rb.AddForce(0, 0, speed*Time.deltaTime, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            endurance--;
            if(endurance <= 0)
            {
                Die();
            }
        }
    }
}
