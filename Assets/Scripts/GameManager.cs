using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int score;

    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject restartButton;
    public GameObject gameOver;
    private bool gameOverCheck = false;
    
    
    private void Start()
    {
        
        playButton.SetActive(true);
        gameOver.SetActive(false);
        
        
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    
    public void Play()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        
        playButton.SetActive(false);
        gameOver.SetActive(false);
        restartButton.SetActive(false);

        Time.timeScale = 1f;

        player.enabled = true;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Restart()
    {
        Reload();
        Play();
    }
    
    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        restartButton.SetActive(true);
        Pause();
    }


}
