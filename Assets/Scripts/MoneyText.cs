using UnityEngine;
using TMPro;

public class Moneytext : MonoBehaviour
{
    public TextMeshProUGUI moneytext;
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        moneytext.text = gameManager.money.ToString();
    }
}
