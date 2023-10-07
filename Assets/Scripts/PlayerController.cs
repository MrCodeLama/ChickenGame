using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public bool gm = false;
   public GameOverScreen gameOverScreen;
   public float speed;
   public Rigidbody rb;
   public bool _isOnGround = false;
   public int scinIndex;
   public GameObject[] scins;
   private SpeedController speedcontroller;
   public int Score = 0;
   
   private void Start()
   {
      speedcontroller = Camera.main.gameObject.GetComponent<SpeedController>();
      
      scinIndex = transform.GetComponent<ScinControll>().scinIndex;
      scins = transform.GetComponent<ScinControll>().scins;
      rb = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0) && _isOnGround)
      {
         rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
         _isOnGround = false;
      }
      UpdateAnimSpeed();
   }
   
   private void UpdateAnimSpeed()
   {
      speed = speedcontroller.speed;
      scins[scinIndex].GetComponent<Animator>().speed = speed*0.7f;
   }
   
   private void OnCollisionEnter(Collision col)
   {
      if (col.gameObject.name == "Ground")
      {
         _isOnGround = true;
      }
      
      if (col.gameObject.name == "Fence(Clone)")
      {
         gm = true;
         GameOver();
      }
   }

   public void GameOver()
   {
      gameOverScreen.Setup(Score);
   }
}
