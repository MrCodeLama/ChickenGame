using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenRotation : MonoBehaviour
{
    public float rotationSpeed = 30f;
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime); 
    }
}
