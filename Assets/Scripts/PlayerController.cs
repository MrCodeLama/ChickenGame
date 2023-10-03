using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Animator animator;
   public float speed = 0.1f;
   
   public Rigidbody rb;
   public bool _isOnGround = false;

   private void Start()
   {
      animator = GetComponent<Animator>();
      rb = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0) && _isOnGround)
      {
         rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
         _isOnGround = false;
      }

      UpdateSpeed();
      animator.speed = speed;
   }

   private void UpdateSpeed()
   {
      speed += Time.deltaTime * 0.1f;
   }
   private void OnCollisionEnter(Collision col)
   {
      if (col.gameObject.name == "Ground")
      {
         _isOnGround = true;
      }
   }
}
