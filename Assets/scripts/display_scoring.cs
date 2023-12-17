using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    public void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }
}
