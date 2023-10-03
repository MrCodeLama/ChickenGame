using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceMover : MonoBehaviour
{
    public float speed = 0.2f;
    public SpeedController speedcntrl;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        speedcntrl = Camera.main.gameObject.GetComponent<SpeedController>();
        UpdateSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime *(-1f * 7f));
        if (!IsVisibleByCamera())
        {
            // Destroy the object
            Destroy(gameObject);
        }
        UpdateSpeed();
    }
    
    private void UpdateSpeed()
    {
        speed = speedcntrl.speed;
    }
    
    private bool IsVisibleByCamera()
    {
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);
        return (viewportPos.x > -0.2f);
    }
    
}
