using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("MainMenuManager Started");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonPressed()
    {
        ScoreManager.instance.ResetScore();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
