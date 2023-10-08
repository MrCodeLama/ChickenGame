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

    private void Start()
    {
        Checkpoint = GameObject.FindWithTag("Fence").transform.GetChild(1).GetComponent<BoxCollider>();
    }

    void Update()
    {
        _isGameOver = Camera.main.GetComponent<PlayMode>()._isGameOver;

        if (!_isGameOver)
            scoreText.text = "Score: " + score.ToString();
        
    }
    public void IncrementScore()
    {
        score += 1;
    }
}
