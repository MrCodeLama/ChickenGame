using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMover : MonoBehaviour
{
    private SpeedController speedcontroller;    
    public float speed = 0.2f;
    private float removex = -30.6f;
    public List<GameObject> floors;
    public Vector3 movement;
    private bool _isGameOver;

    void Start()
    {
        speedcontroller = Camera.main.GetComponent<SpeedController>();
        for (int i = 0; i < 2; i++)
        {
            floors.Add(transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        _isGameOver = Camera.main.GetComponent<PlayMode>()._isGameOver;
        if (!_isGameOver)
        {
            UpdateParameters();
            moveFloor();
        }
    }

    private void moveFloor()
    {
        foreach (GameObject el in floors)
        {
            if (el.transform.position.x <= removex)
            {
                el.transform.position = new Vector3(20.6f - speed * 0.2f, -0.8f,0);
                el.transform.Translate(movement);
            }
            el.transform.Translate(movement);
        }
    }
    private void UpdateParameters()
    {
        speed = speedcontroller.speed;
        movement = speedcontroller.movement;
    }
}
