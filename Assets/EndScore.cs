using UnityEngine;
using System.Collections;
using TMPro;

public class EndScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Final Score: " + ScoreManager.instance.Score.ToString();
        highScoreText.text = "High Score: " + ScoreManager.instance.HighScore.ToString();
        ScoreManager.instance.ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
