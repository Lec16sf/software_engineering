using UnityEngine;
using System.Collections;

public class Player : Character
{
    public float forwardForce = 500f;
    public float sidewaysForce = 20f;
    public Animator animator;
    public GameObject boss;
    public GameManager gameManager;

    public override void Start()
    {
        base.Start();
        boss = GameObject.FindWithTag("BOSS");
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        GameObject boss = GameObject.FindWithTag("BOSS");
        if(boss == null || boss.GetComponent<Rigidbody>().position.z > rb.position.z+10)
        {
            rb.AddForce(0, 0, forwardForce*Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        animator.SetFloat("health", health);
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Enemy")
        {
            this.ChangeHealth(collisionInfo.collider.GetComponent<Enemy>().health*(1-gameManager.damageReductionRate));
        }
    }

    public override void Die()
    {
        forwardForce = 0;
        FindObjectOfType<GameManager>().EndGame();
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.CompareTag("Fire"))
        {
            Fire fire = collisionInfo.GetComponent<Fire>();
            if (fire != null)
            {
                this.ChangeHealth(fire.health);
            }
        }
    }



}
