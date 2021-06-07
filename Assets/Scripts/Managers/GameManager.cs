using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }

    // public delegate void OnGameStart();
    // public event OnGameStart onStartGame;



    public GameObject gameOverScreen;
    public GameObject startScreen;
    public Text scoreText;

      public int score;

      private void Awake() 
      {
        
        Time.timeScale = 0;
        ObjectPooler.Instance.InitializePool();  
    
      }

       private void Update() {
        
         UpdateScore();

      }

      public void GameOver()
      {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
      }

      public void RestartGame()
      {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
      }

      public void AddScore(string type)
      {
        if(type == "Score")
        {
            score++;
        }else if(type == "Crate")
        {
          score += 10;
        }
          
      }

      private void UpdateScore()
      {
        scoreText.text = score.ToString();
      }

      public void Resume()
      {
          Time.timeScale = 1;
          startScreen.SetActive(false);
      }

      
      
}
