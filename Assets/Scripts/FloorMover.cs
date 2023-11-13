using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMover : MonoBehaviour
{
    private SpeedController speedCntrl;
    private float speed;
    private float removeX = -30.6f;
    public List<GameObject> floors;
    private PlayMode playMode;

    void Start()
    {
        speedCntrl = Camera.main.GetComponent<SpeedController>();
        for (int i = 0; i < 2; i++)
        {
            floors.Add(transform.GetChild(i).gameObject);
        }
        speed = speedCntrl.speed;
        playMode = Camera.main.GetComponent<PlayMode>();
    }

    void Update()
    {
        if (!playMode._isGameOver)
        {
            speed = speedCntrl.speed;
            moveFloor();
        }
    }

    private void moveFloor()
    {
        foreach (GameObject el in floors)
        {
            if (el.transform.position.x <= removeX)
            {
                el.transform.position = new Vector3(20.6f - speed * 0.2f, -0.8f,0);
            }
            el.transform.Translate(speedCntrl.movement);
        }
    }
}
