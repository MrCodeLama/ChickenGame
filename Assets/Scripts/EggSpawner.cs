using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public int test;
    public Collider[] colliders;
    public GameObject commonEgg;
    private float nextSpawnTime;
    
    
    void Start()
    {
        //nextSpawnTime = Random.Range(speed, speed*10f);
        nextSpawnTime = 2f;
    }
    
    void Update()
    {
        nextSpawnTime -= Time.deltaTime;
        if (nextSpawnTime <= 0)
        {
            nextSpawnTime = Random.Range(1f,2f);
            
            colliders = Physics.OverlapBox(new Vector3(7f, 0, 0f), new Vector3(1.5f, 0.3f, 0.3f));
            if (colliders.Length == 0)
            {
                test = colliders.Length;
                SpawnEgg();
            }
            else
            {
                test = -1;
            }
        }
    }
    
    void SpawnEgg()
    {
        GameObject newEgg = Instantiate(commonEgg, new Vector3(6f, -0.2f, 0f), Quaternion.identity);
        
        newEgg.transform.parent = transform;
    }
    
}