using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public GameObject commonEgg;
    public GameObject legendaryEgg;
    public SpeedController speedCntrl;
    private float nextSpawnTime;
    private bool previousLegendaryEgg;
    private float maxSpawnTime;
    private float minSpawnTime;
    private Vector3 spawnPoint;
    private Collider[] colliders;
    void Start()
    {
        speedCntrl = Camera.main.GetComponent<SpeedController>();
        nextSpawnTime = 2f;
        previousLegendaryEgg = false;
        spawnPoint = new Vector3(6f, -0.2f, 0f);
    }
    
    void Update()
    {
        nextSpawnTime -= Time.deltaTime;
        if (nextSpawnTime <= 0)
        {
            maxSpawnTime = 3 / (speedCntrl.speed * 3) + 0.3f;
            minSpawnTime = 1 / (speedCntrl.speed * 3);
            
            nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            
            colliders = Physics.OverlapBox(
                spawnPoint+Vector3.up *1.4f, 
                    new Vector3(0.6f, 0.3f, 0.3f)
                    );
            
            if (colliders.Length == 0)
                SpawnEgg();
        }
    }
    
    void SpawnEgg()
    {
        GameObject egg;
        if (Random.Range(1, 10) % 9 == 0 && !previousLegendaryEgg)
        {
            egg = legendaryEgg;
            previousLegendaryEgg = true;
        }
        else
        {
            egg = commonEgg;
            previousLegendaryEgg = false;
        }
        GameObject newEgg = Instantiate(egg, spawnPoint, Quaternion.identity);
        
        newEgg.transform.parent = transform;
    }
    
}