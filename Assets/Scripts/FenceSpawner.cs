using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSpawner : MonoBehaviour
{
    public GameObject Fence;
    public float speed = 0.2f;
    private float nextSpawnTime;
    public SpeedController speedcntrl;
    
    void Start()
    {
        //nextSpawnTime = Random.Range(speed, speed*10f);
        nextSpawnTime = speed * 0f;

        speedcntrl = Camera.main.gameObject.GetComponent<SpeedController>();
        UpdateSpeed();
    }
    
    void Update()
    {
        nextSpawnTime -= Time.deltaTime;
        if (nextSpawnTime <= 0)
        {
            SpawnFence();
            //nextSpawnTime = Random.Range(speed*5f, speed*10f);
            if (speed < 0.3f)
            {
                nextSpawnTime = Random.Range(2f / (speed * 4.1f), 2f / (speed * 4.1f) + 2f);
            }
            else if(speed < 1f)
            {
                nextSpawnTime = Random.Range(2f/(speed + 0.7f), 2f/(speed + 0.7f) + 2f);
            }
            else
            {
                nextSpawnTime = Random.Range(2f/(speed), 2f/(speed) + 1f);
            }
        }

        UpdateSpeed();
    }
    
    private void UpdateSpeed()
    {
        speed = speedcntrl.speed;
    }
    
    void SpawnFence()
    {
        GameObject newFence = Instantiate(Fence, new Vector3(6f, -0.5f, 0f), Quaternion.identity);
        Vector3 spawnPosition = new Vector3(6f, -0.5f, 0f);
        newFence.transform.position = spawnPosition;
        newFence.transform.parent = transform;
    }
    
}
