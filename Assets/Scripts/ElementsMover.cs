using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsMover : MonoBehaviour
{
    public SpeedController speedcontroller;
    private Camera mainCamera;
    public Vector3 movement;
    private bool _isGameOver;

    void Start()
    {
        mainCamera = Camera.main;
        speedcontroller = mainCamera.gameObject.GetComponent<SpeedController>();
        UpdateParameters();
    }

    // Update is called once per frame
    void Update() {
        _isGameOver = mainCamera.GetComponent<PlayMode>()._isGameOver;

        if (!_isGameOver)
        {
            transform.Translate(movement);
            if (!IsVisibleByCamera())
            {
                // Destroy the object
                Destroy(gameObject);
            }
            UpdateParameters();
        }
    }
    
    private void UpdateParameters()
    {
        movement = speedcontroller.movement;
    }
    
    private bool IsVisibleByCamera()
    {
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);
        return (viewportPos.x > -0.2f);
    }
}
