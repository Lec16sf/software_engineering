using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Character character;
    public Camera Camera;
    public TextMeshProUGUI healthBarText;
    public Vector3 offset = new Vector3(0, 1.5f, 0);

    void Start()
    {
        Camera = Camera.main;
    }

    void FixedUpdate()
    {
        healthBarText.text = character.health.ToString("0");
        transform.position = Camera.WorldToScreenPoint(character.transform.position + offset);
    }
}
