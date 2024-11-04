using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.getBuff();
            Debug.Log("getbuff");
        }
    }
}
