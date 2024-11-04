using UnityEngine;
using TMPro;

public class Board : MonoBehaviour
{
    public TextMeshPro text;
    public int BuffIndex;
    public Color textColor = Color.black;
    public float textSize = 1f;
    public GameManager gameManager;
    public Player player;
    
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        text.text = "测试测hi是爱上帝阿萨测试策划一二一但是"+BuffIndex.ToString();
        text.color = textColor;
        text.fontSize = textSize;
    }

    void FixedUpdate()
    {
        if(player.transform.position.z > transform.position.z)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (Mathf.Abs(other.transform.position.x - transform.position.x) < 2.4f))
        {
            Destroy(gameObject);
            gameManager.getBuff(BuffIndex);
            Debug.Log("getbuff"+BuffIndex);
        }
    }
}
