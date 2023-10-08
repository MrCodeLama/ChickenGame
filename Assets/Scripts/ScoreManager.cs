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
    public int highScore;
    
    private void Start()
    {
        Checkpoint = GameObject.FindWithTag("Fence").transform.GetChild(1).GetComponent<BoxCollider>();
        highScore = GameObject.Find("SaveManager").GetComponent<SaveManager>().highScore;
    }

    void Update()
    {
        _isGameOver = Camera.main.GetComponent<PlayMode>()._isGameOver;

        if (!_isGameOver)
        {
            scoreText.text = "Score: " + score.ToString();
            if (highScore <= score)
            {
                setNewHighScore();
            }
        }
            
        
        
        
    }
    public void IncrementScore()
    {
        score += 1;
    }
    
    public void setNewHighScore()
    {
        SaveManager.instance.highScore = highScore;
    }
}
