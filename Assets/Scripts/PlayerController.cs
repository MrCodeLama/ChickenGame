using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public SpeedController speedcntrl;
   public float speed;
   public Rigidbody rb;
   public bool _isOnGround = false;
   public int index;
   public GameObject[] characters;
   private void Start()
   {
      index = transform.GetComponent<PlayerSelect>().index;
      characters = transform.GetComponent<PlayerSelect>().characters;
      
      speedcntrl = Camera.main.gameObject.GetComponent<SpeedController>();
      rb = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0) && _isOnGround)
      {
         rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
         _isOnGround = false;
      }
      UpdateSpeed();
      
   }
   
   

   private void UpdateSpeed()
   {
      speed = speedcntrl.speed;
      characters[index].GetComponent<Animator>().speed = speed*0.7f;
   }
   
   private void OnCollisionEnter(Collision col)
   {
      if (col.gameObject.name == "Ground")
      {
         _isOnGround = true;
      }
   }
}
