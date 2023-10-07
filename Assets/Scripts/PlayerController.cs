using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public SoundManager soundManager;
   public int score;
   public bool gameover = false;
   private bool _isOnGround;
   private int skinIndex;
   private float speed;
   private Rigidbody rb;
   private GameObject[] skins;
   private SpeedController speedController;
   public GameOverScreen gameOverScreen;  
   
   private void Start()
   {
      soundManager = transform.GetComponent<SoundManager>();
      //skinIndex = transform.GetComponent<SkinControll>().skinIndex;
      //skins = transform.GetComponent<SkinControll>().skins;
      speedController = Camera.main.gameObject.GetComponent<SpeedController>();
      rb = GetComponent<Rigidbody>();
      _isOnGround = false;
      score = 0;
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0) && _isOnGround)
      {
         soundManager.PlaySound();
         rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
         _isOnGround = false;
      }
      UpdateAnimSpeed();
   }
   
   private void UpdateAnimSpeed()
   {
      speed = speedController.speed;
      skins[skinIndex].GetComponent<Animator>().speed = speed*0.7f;
   }
   
   private void OnCollisionEnter(Collision col)
   {
      if (col.gameObject.tag == "Fence")
      {
         gameover = true;
         GameOver();
      }
      if (col.gameObject.name == "Ground")
      {
         _isOnGround = true;
      }
   }

   public void GameOver()
   {
      gameOverScreen.Setup(score);
   }
}
