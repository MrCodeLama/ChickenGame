using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private bool _isGameOver;
    public bool _isOnGround;
    public float speed;
    private SpeedController speedController;
    private Animator playerAnimator;
    void Start()
    {
        speedController = Camera.main.GetComponent<SpeedController>();
        playerAnimator = GameObject.Find("Player").GetComponentInChildren<Animator>();
    }
    void Update()
    {
        _isOnGround = GameObject.Find("Player").GetComponentInChildren<PlayerController>()._isOnGround;
        _isGameOver = Camera.main.GetComponent<PlayMode>()._isGameOver;
        //speed = (_isGameOver || !_isOnGround) ? 0f : speedController.speed;
        //speed = (_isGameOver && _isOnGround) ? 0f : speedController.speed;
        speed = (!_isGameOver && _isOnGround) ? speedController.speed : 0.2f;
        speed = (_isGameOver) ? 0 : speed;
        playerAnimator.speed = speed*0.8f;
    }
    
}
