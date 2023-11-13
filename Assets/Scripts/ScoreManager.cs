using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    private BoxCollider Checkpoint;
    private bool _isGameOver;
    private int highScore;
    public bool _isNewHighScore;
    private PlayMode playMode;
    private void Start()
    {
        highScore = SaveManager.instance.highScore;
        //check if works, maybe foreach
        Checkpoint = GameObject.FindWithTag("Fence").transform.GetChild(1).GetComponent<BoxCollider>();
        playMode = Camera.main.GetComponent<PlayMode>();
    }

    void Update()
    {
        //_isGameOver = Camera.main.GetComponent<PlayMode>()._isGameOver;
        _isGameOver = playMode._isGameOver;
        
        if (!_isGameOver)
        {
            _isNewHighScore = highScore < score;
            scoreText.text = "Score: " + score.ToString();
        }
        else if (highScore <= score)
        {
            setNewHighScore();
        }
    }
    public void IncrementScore()
    {
        score += 1;
    }
    
    public void setNewHighScore()
    {
        SaveManager.instance.highScore = score;
        SaveManager.instance.Save();
    }
}
