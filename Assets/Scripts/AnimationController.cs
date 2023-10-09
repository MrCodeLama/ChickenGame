using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private bool _isGameOver;
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
        _isGameOver = Camera.main.GetComponent<PlayMode>()._isGameOver;
        speed = _isGameOver ? 0f : speedController.speed;

        playerAnimator.speed = speed*0.8f;
    }
    
}
