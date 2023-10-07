using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceMover : MonoBehaviour
{
    public float speed = 0.2f;
    public SpeedController speedcontroller;
    private Camera mainCamera;
    public Vector3 movement;
    void Start()
    {
        mainCamera = Camera.main;
        speedcontroller = mainCamera.gameObject.GetComponent<SpeedController>();
        UpdateParameters();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement);
        if (!IsVisibleByCamera())
        {
            // Destroy the object
            Destroy(gameObject);
        }
        UpdateParameters();
    }
    
    private void UpdateParameters()
    {
        speed = speedcontroller.speed;
        movement = speedcontroller.movement;
    }
    
    private bool IsVisibleByCamera()
    {
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);
        return (viewportPos.x > -0.2f);
    }
}
