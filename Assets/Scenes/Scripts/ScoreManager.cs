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

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }
    public bool Level1 = false;
    void Update()
    {
        if (!Level1 && score >= 50)
        {
            Level1 = true;
            Debug.Log("fart");
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded: " + scene.name);
        scoreText = null;

        if (scene.name == "GameScene")
        {
            GameObject obj = GameObject.FindWithTag("ScoreText");
            if (obj != null)
            {
                obj.SetActive(true);
                scoreText = obj.GetComponent<TextMeshProUGUI>();
                scoreText.gameObject.SetActive(true);
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


    }
// fart


    public void AddScore(int amount)
    {
        score += amount;
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
