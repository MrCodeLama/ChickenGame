using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public float speed = 0.2f;

    void Update()
    {
        UpdateSpeed();
    }
    private void UpdateSpeed()
    {
        speed += Time.deltaTime * 0.001f;
    }
}
