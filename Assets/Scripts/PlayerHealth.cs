using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public Character character;
    public TextMeshProUGUI healthBarText;

    void Start()
    {
        character = GameObject.FindWithTag("Player").GetComponent<Character>();
    }

    void FixedUpdate()
    {
        healthBarText.text = "生命\n" + character.health.ToString("0");
    }
}
