using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FenceSpawner : MonoBehaviour
{
    public GameObject Fence;
    private float speed = 0.2f;
    private float nextSpawnTime;
    private SpeedController speedCntrl;
    
    void Start()
    {
        nextSpawnTime = 0.0f;
        speedCntrl = Camera.main.GetComponent<SpeedController>();
        speed = speedCntrl.speed;
    }
    
    void Update()
    {
        nextSpawnTime -= Time.deltaTime;
        if (nextSpawnTime <= 0)
        {
            SpawnFence();
            if (speed < 0.3f)
            {
                nextSpawnTime = Random.Range(2f/(speed * 4.1f), 2f/(speed * 4.1f) + 2f);
            }
            else if(speed < 1f)
            {
                nextSpawnTime = Random.Range(1.5f/(speed + 0.7f), 1.5f/(speed + 0.7f) + 1.5f);
            }
            else
            {
                nextSpawnTime = Random.Range(1.5f/(speed), 1.5f/(speed) + 0.5f);
            }
        }
        speed = speedCntrl.speed;
    }
    
    void SpawnFence()
    {
        GameObject newFence = Instantiate(Fence, new Vector3(6f, -0.5f, 0), Quaternion.identity);
        Vector3 spawnPosition = new Vector3(6f, -0.5f, transform.position.z);
        newFence.transform.position = spawnPosition;
        newFence.transform.parent = transform;
    }
    
}
