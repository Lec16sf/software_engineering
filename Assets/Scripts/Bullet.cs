using UnityEngine;

public class Bullet : Character
{
    public Rigidbody rb;
    public int finalEndurance = 1; 
    public int endurance = 1; //弹药耐久
    public float speed = 20f;
    public float lifetime = 5f;

    public override void Start()
    {
        endurance = finalEndurance;
        Destroy(gameObject, lifetime);
    }

    public override void FixedUpdate()
    {
        rb.AddForce(0, 0, speed*Time.deltaTime, ForceMode.VelocityChange);
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
