using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private bool _isGameOver;
    private bool _isOnGround;
    private float speed;
    private SpeedController speedCntrl;
    private Animator playerAnimator;
    private PlayerController playerCntrl;
    void Start()
    {
        speedCntrl = Camera.main.GetComponent<SpeedController>();
        playerAnimator = GameObject.Find("Player").GetComponentInChildren<Animator>();
        playerCntrl = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        _isOnGround = playerCntrl._isOnGround;
        _isGameOver = Camera.main.GetComponent<PlayMode>()._isGameOver;
        speed = (!_isGameOver && _isOnGround) ? speedCntrl.speed : 0.2f;
        speed = (_isGameOver) ? 0 : speed;
        playerAnimator.speed = speed*0.8f;
    }
    
}
