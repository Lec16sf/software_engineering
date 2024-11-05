using UnityEngine;

public class Enemy : Character
{
    public Canvas canvas;
    public HealthBar healthBar;
    public Chest chest;
    public Character player;

    public override void Start()
    {
        base.Start();
        if (canvas == null)
        {
            canvas = GameObject.FindObjectOfType<Canvas>();
        }
        player = GameObject.FindObjectOfType<Player>();
        healthBar = Instantiate(healthBar, canvas.transform);
        healthBar.character = this;
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if(player.rb.position.z > rb.position.z)
        {
            Disappear();
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Player")
        {
            this.ChangeHealth(collisionInfo.collider.GetComponent<Player>().health);
        }
        if(collisionInfo.collider.tag == "Bullet")
        {
            this.ChangeHealth(collisionInfo.collider.GetComponent<Bullet>().health);
        }
    }

    public override void Die()
    {
        Disappear();
        Vector3 chestPos = transform.position + new Vector3(0, -1, 0);
        Instantiate(chest, chestPos, Quaternion.identity);
    }

    public void Disappear()
    {
        if(healthBar != null){
            Destroy(healthBar.gameObject);
            healthBar = null;
        }
        Destroy(gameObject);
    }

}
