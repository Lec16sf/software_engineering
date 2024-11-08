using UnityEngine;

public class Fire : Character
{
    public float damage = 25f;
    public int finalEndurance = 1; 
    public int endurance = 1;
    public float speed = 20f;
    public float lifetime = 5f;


    public override void Start()
    {
        endurance = finalEndurance;
        Destroy(gameObject, lifetime);
        health = damage;
    }
    public override void FixedUpdate()
    {

        rb.velocity = -transform.forward * speed;
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

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.CompareTag("Player"))
        {
            endurance--;
            if(endurance <= 0)
            {
                Die();
            }
            Debug.Log(this.health);
        }
    }
}
