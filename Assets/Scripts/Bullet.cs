using UnityEngine;

public class Bullet : Character
{
    public float damage;
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
    }

    public override void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
        damage = gameManager.damage;
        endurance = gameManager.endurance;
        speed = gameManager.speed;
        criticalHitRate = gameManager.criticalHitRate;
        criticalHitEnhanceRate = gameManager.criticalHitEnhanceRate;
        damageEnhanceRate = gameManager.damageEnhanceRate;
        vampireRate = gameManager.vampireRate;

        health = damage * damageEnhanceRate;
        if(Random.value < criticalHitRate)
        {
            health *= criticalHitEnhanceRate;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            endurance--;
            player.health += health * vampireRate;
            if(endurance <= 0)
            {
                Die();
            }
        }
    }
}
