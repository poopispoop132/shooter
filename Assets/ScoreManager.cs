using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;

    private int score = 0;
    private int highScore = 0;

    public int Score => score;
    public int HighScore => highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Listen for scene changes
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        GameObject obj = GameObject.FindWithTag("ScoreText");
        Debug.Log("Found ScoreText Object: " + (obj != null));
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Clear old reference every scene
        Debug.Log("Scene Loaded: " + scene.name);
        scoreText = null;

        // Only gameplay scene should show the score
        if (scene.name == "GameScene") // <-- use YOUR gameplay scene name
        {
            GameObject obj = GameObject.FindWithTag("ScoreText");
            if (obj != null)
            {
                scoreText = obj.GetComponent<TextMeshProUGUI>();
                UpdateScoreText();
            }
            else
            {
                // RectTransform rt = scoreText.GetComponent<RectTransform>();
                // if (scene.name == "MainMenu")
                //     rt.anchoredPosition = new Vector2(0, 75f);
                // else if (scene.name == "Retry")
                //     rt.anchoredPosition = new Vector2(0, 45.9f);
                Debug.LogWarning("ScoreText not found in GameScene");
            }
        }
        // Any other scene (MainMenu, Retry, etc) does nothing
        else
        {
        }
    }



    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    public void SaveHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

}
