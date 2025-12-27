using UnityEngine;
using System.Collections;


public class DeathScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ScoreManager.instance.SaveHighScore();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Retry");
            Destroy(gameObject);

        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

