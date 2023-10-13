using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public float speed = 0.2f;
    public Vector3 movement;
    private bool _isGameOver;
    private float deltaSpeed;
    private bool _isIncreasing = true;
    void Update()
    {
        _isGameOver = Camera.main.GetComponent<PlayMode>()._isGameOver;
        if (!_isGameOver)
        {
            deltaSpeed = Time.deltaTime * 0.1f;
            if (_isIncreasing)
            {
                speed += deltaSpeed;
            }
            else
            {
                speed -= deltaSpeed;
            }

            if (speed >= 1.5f)
            {
                _isIncreasing = !_isIncreasing;
            }

            if (speed <= 0.8f && !_isIncreasing)
            {
                _isIncreasing = !_isIncreasing;
            }
            movement = Vector3.right * speed * Time.deltaTime * (-1f * 7f);   
        }
        
    }
}
