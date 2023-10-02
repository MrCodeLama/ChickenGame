using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float Speed = 10f;
   public Rigidbody rb;
   public bool _isOnGround = false;

   private void Start()
   {
      rb = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0) && _isOnGround)
      {
         rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
         _isOnGround = false;
      }
   }

   private void OnCollisionEnter(Collision col)
   {
      if (col.gameObject.name == "Ground")
      {
         _isOnGround = true;
      }
   }
}
