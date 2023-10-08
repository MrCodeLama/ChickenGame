using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public float speed = 0.2f;
    public Vector3 movement;
    private bool _isGameOver;

    void Update()
    {
        _isGameOver = Camera.main.GetComponent<PlayMode>()._isGameOver;
        if (!_isGameOver)
        {
            if (speed <= 1.5)
            {
                speed += Time.deltaTime * 0.01f;
            }
            movement = Vector3.right * speed * Time.deltaTime * (-1f * 7f);   
        }
    }
}
