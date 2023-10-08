using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public bool _isGameOver;
   public int score = 0;
   private bool _isOnGround = false;
   private Rigidbody rb;
   public GameOverScreen gameOverScreen;
   public SoundManager soundManager;
   public ScoreManager scoreManager;
   
   private void Start()
   {
      _isGameOver = false;
      rb = GetComponent<Rigidbody>();
      soundManager = GameObject.Find("Jump").GetComponent<SoundManager>();
      scoreManager = Camera.main.GetComponent<ScoreManager>();
     
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0) && _isOnGround && !_isGameOver)
      {
         soundManager.PlaySound();
         rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
         _isOnGround = false;
      }
   }
   
   private void OnCollisionEnter(Collision col)
   {
      _isOnGround = col.gameObject.name == "Ground";
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.name == "CheckPoint")
      {
         scoreManager.IncrementScore();
      }
      
      if (other.gameObject.tag == "Fence")
      {
         _isGameOver = true;
         Camera.main.GetComponent<PlayMode>()._isGameOver = true;
         score = Camera.main.GetComponent<ScoreManager>().score;
         GameOver();
      }
   }

   private void GameOver()
   {
      GameObject.Find("Fences").GetComponent<FenceSpawner>().enabled = false;
      gameOverScreen.Setup(score);
   }
}
