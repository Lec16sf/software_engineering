using UnityEngine;

public class Enemy : Character
{
    public Canvas canvas;
    public HealthBar healthBar;

    public override void Start()
    {
        base.Start();
        if (canvas == null)
        {
            canvas = GameObject.FindObjectOfType<Canvas>();
        }
        healthBar = Instantiate(healthBar, canvas.transform);
        healthBar.character = this;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.collider.tag);
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
        Destroy(healthBar.gameObject);
        Destroy(gameObject);
    }
}
