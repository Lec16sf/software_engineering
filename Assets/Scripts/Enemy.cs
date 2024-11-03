using UnityEngine;

public class Enemy : Character
{
    public Canvas canvas;
    public HealthBar healthBar;
    public Chest chest;

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
        Vector3 chestPos = transform.position + new Vector3(0, -1, 0);
        Instantiate(chest, chestPos, Quaternion.identity);
    }

    void OnBecameVisible()
    {
        // 当敌人进入摄像机视野时显示血量条
        healthBar.gameObject.SetActive(true);
    }

    void OnBecameInvisible()
    {
        if (healthBar != null)
        {
            // 当敌人离开摄像机视野时隐藏血量条
            healthBar.gameObject.SetActive(false);
        }
    }
}
