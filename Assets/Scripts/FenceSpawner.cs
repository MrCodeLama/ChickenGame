using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSpawner : MonoBehaviour
{
    public GameObject Fence;
    public float speed = 1f;
    private Camera mainCamera;
    private float nextSpawnTime;
    
    void Start()
    {
        mainCamera = Camera.main;
        nextSpawnTime = Random.Range(speed, speed*4f);
    }
    
    void Update()
    {
        nextSpawnTime -= Time.deltaTime;
        if (nextSpawnTime <= 0)
        {
            SpawnFence();
            nextSpawnTime = Random.Range(speed, speed*4f);
        }
    }
    
    void SpawnFence()
    {
        GameObject newFence = Instantiate(Fence, new Vector3(6f, -0.5f, 0f), Quaternion.identity);
        Vector3 spawnPosition = new Vector3(6f, -0.5f, 0f);
        newFence.transform.position = spawnPosition;
        newFence.transform.parent = transform;
    }
    
}
