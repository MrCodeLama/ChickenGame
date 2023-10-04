using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public float speed = 0.2f;
    public Vector3 movement;
    void Update()
    {
        movement = Vector3.right * speed * Time.deltaTime * (-1f * 7f);
        if (speed <= 1.5)
        {
            speed += Time.deltaTime * 0.01f;
        }
        
    }
}
