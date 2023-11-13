using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public bool _isGameOver;
   private int score;
   public bool _isOnGround = false;
   public GameObject fireWorks;
   public GameObject fireWorksL;
   private Rigidbody rb;
   public GameOverScreen gameOverScreen;
   private SoundManager jumpSound;
   private SoundManager collectSound;
   private ScoreManager scoreManager;
   private MoneyManager moneyManager;
   public Animator tab10;
   public Animator tab1;
   private PlayMode playMode;
   private FenceSpawner fenceSpawner;
   
   private void Start()
   {
      _isGameOver = false;
      rb = GetComponent<Rigidbody>();
      
      jumpSound = GameObject.Find("Jump").GetComponent<SoundManager>();
      collectSound = GameObject.Find("Collect").GetComponent<SoundManager>();
      
      scoreManager = Camera.main.GetComponent<ScoreManager>();
      moneyManager = Camera.main.GetComponent<MoneyManager>();

      playMode = Camera.main.GetComponent<PlayMode>();
      fenceSpawner = GameObject.Find("Fences").GetComponent<FenceSpawner>();
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0) && _isOnGround && !_isGameOver)
      {
         jumpSound.PlaySound();
         rb.AddForce(new Vector3(0, 6f, 0), ForceMode.Impulse);
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
         scoreManager.IncrementScore();

      if (other.gameObject.tag == "Egg")
      {
         collectSound.PlaySound();
         createFireworks(false);
         moneyManager.AddMoney(false);
         Destroy(other.gameObject);
         tab1.Rebind();
         tab10.Rebind();
         tab1.Play("New Animation");
      }
      
      if (other.gameObject.tag == "legEgg")
      {
         collectSound.PlaySound();
         createFireworks(true);
         moneyManager.AddMoney(true);
         Destroy(other.gameObject);
         tab1.Rebind();
         tab10.Rebind();
         tab10.Play("New Animation");
      }
      
      if (other.gameObject.tag == "Fence")
      {
         _isGameOver = true;
         playMode._isGameOver = true;
         score = scoreManager.score;
         GameOver();
      }
   }
   

   private void GameOver()
   {
      fenceSpawner.enabled = false;
      gameOverScreen.Setup(score);
   }

   private void createFireworks(bool _isLegendary)
   {
      Instantiate((_isLegendary) ? fireWorksL : fireWorks, transform.position + new Vector3(0.5f,0,0), Quaternion.identity);
   }
}
