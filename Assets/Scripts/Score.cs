using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void FixedUpdate()
    {
        scoreText.text = "Score:" + GameManager.score.ToString();
    }
}
