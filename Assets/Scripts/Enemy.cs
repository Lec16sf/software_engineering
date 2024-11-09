using UnityEngine;

public class Enemy : Character
{
    public Canvas canvas;
    public HealthBar healthBar;
    public Chest chest;
    public Character player;
    public Vector3 HealthBaroffset = new Vector3(0, 1.5f, 0);
    public Renderer[] renderers;
    public Collider[] colliders;
    public float activationDistance = 30f;

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
        healthBar.offset = HealthBaroffset;
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderers)
        {
            rend.enabled = false;
        }
        colliders = GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            col.enabled = false;
        }
        healthBar.gameObject.SetActive(false);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if(rb.position.z < player.rb.position.z+activationDistance)
        {
            foreach (Renderer rend in renderers)
            {
                rend.enabled = true;
            }
            foreach (Collider col in colliders)
            {
                col.enabled = true;
            }
            if(healthBar != null)
            {
            healthBar.gameObject.SetActive(true);
            }
        }
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

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.CompareTag("Player"))
        {
            Player player = collisionInfo.GetComponent<Player>();
            if (player != null)
            {
                this.ChangeHealth(player.health);
            }
        }
        else if (collisionInfo.CompareTag("Bullet"))
        {
            Bullet bullet = collisionInfo.GetComponent<Bullet>();
            if (bullet != null)
            {
                this.ChangeHealth(bullet.health);
            }
        }
    }

    public override void Die()
    {
        Disappear();
        Destroy(gameObject);
        Vector3 chestPos = transform.position + new Vector3(0, 0, 0);
        Instantiate(chest, chestPos, Quaternion.identity);
    }

    public void Disappear()
    {
        if(healthBar != null){
            Destroy(healthBar.gameObject);
            healthBar = null;
        }
    }

}
