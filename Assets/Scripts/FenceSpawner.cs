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
            nextSpawnTime = speed * 2f;
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
