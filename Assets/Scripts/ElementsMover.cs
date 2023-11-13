using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsMover : MonoBehaviour
{
    private SpeedController speedCntrl;
    private Camera mainCamera;
    private PlayMode playMode;
    
    void Start()
    {
        mainCamera = Camera.main;
        speedCntrl = mainCamera.gameObject.GetComponent<SpeedController>();
        playMode = mainCamera.GetComponent<PlayMode>();
    }
    
    void Update() {
        if (!playMode._isGameOver)
        {
            transform.Translate(speedCntrl.movement);
            if (!IsVisibleByCamera())
            {
                Destroy(gameObject);
            }
        }
    }
    
    private bool IsVisibleByCamera()
    {
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);
        return (viewportPos.x > -0.2f);
    }
}
