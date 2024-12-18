using UnityEngine;

public class Bullet : Character
{
    public float damage = 25f;
    public int finalEndurance = 1; 
    public int endurance = 1;
    public float speed = 20f;
    public float lifetime = 5f;
    public float criticalHitRate = 0;
    public float criticalHitEnhanceRate = 0;
    public float damageEnhanceRate = 0;
    public float vampireRate = 0;

    public GameManager gameManager;
    public Player player;

    public override void Start()
    {
        endurance = finalEndurance;
        Destroy(gameObject, lifetime);

        gameManager = GameObject.FindObjectOfType<GameManager>();

        player = GameObject.FindObjectOfType<Player>();

        damage = gameManager.damage;
        endurance = gameManager.endurance;
        speed = gameManager.speed;
        criticalHitRate = gameManager.criticalHitRate;
        criticalHitEnhanceRate = gameManager.criticalHitEnhanceRate;
        damageEnhanceRate = gameManager.damageEnhanceRate;
        vampireRate = gameManager.vampireRate;

        health = damage * damageEnhanceRate;
        // Debug.Log("basedamage: " + damage);
        // Debug.Log("damageEnhanceRate: " + damageEnhanceRate);
        // Debug.Log("damage: " + health);
        if(Random.value < criticalHitRate)
        {
            health *= criticalHitEnhanceRate;
            // Debug.Log("damage: " + damage);
            // Debug.Log("criticalHitEnhanceRate: " + criticalHitEnhanceRate);
            // Debug.Log("criticalHitRate: " + criticalHitRate);
            // Debug.Log("critical: " + health);
        }
    }

    public override void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            endurance--;
            player.health += health * vampireRate;
            // Debug.Log(damage);
            if(endurance <= 0)
            {
                Die();
            }
        }
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.CompareTag("Enemy") || collisionInfo.CompareTag("BOSS"))
        {
            endurance--;
            player.health += health * vampireRate;
            // Debug.Log("vampireRate: " + vampireRate);
            // Debug.Log("vampire " + health * vampireRate);
            float enemyhealth = collisionInfo.GetComponent<Enemy>().health;
            collisionInfo.GetComponent<Enemy>().ChangeHealth(health);
            if(endurance <= 0)
            {
                Die();
            }
        }
    }
}
