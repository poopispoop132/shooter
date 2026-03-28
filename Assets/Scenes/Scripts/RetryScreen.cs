using UnityEngine;

public class RetryScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRetryButtonPressed()
    {
        Debug.Log("Retry Button Pressed");
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");

        ScoreManager.instance.ResetScore();
    }
}
