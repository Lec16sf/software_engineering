using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("属性")]
    [SerializeField]public float health;
    public Rigidbody rb;

    public virtual void Start()
    {
    }

    public virtual void FixedUpdate()
    {
    }
    
    public virtual void ChangeHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log("CharacterDie");
        Destroy(gameObject);
    }

}
