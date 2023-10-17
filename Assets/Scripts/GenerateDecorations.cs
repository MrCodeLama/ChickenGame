using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateDecorations : MonoBehaviour
{
    public GameObject[] decorations;
    public float speed = 0.2f;
    public SpeedController speedcntrl;
    public int numberOfElements;
    public int index;
    private float[] rotationAngles = { 0f, 90f, 180f, 270f, 360f };
    private float nextSpawnTime;
    void Start()
    {
        speedcntrl = Camera.main.GetComponent<SpeedController>();
        UpdateSpeed();
        nextSpawnTime = speed * 0f;
    }

    void Update()
    {
        nextSpawnTime -= Time.deltaTime;
        if (nextSpawnTime <= 0)
        {
            GenerateDecorLine();
            nextSpawnTime = 1f/speed;
        }

        UpdateSpeed();
    }

    private void GenerateDecorLine()
    {
        numberOfElements = Random.Range(2,4);
        for (int i = 0; i < numberOfElements; i++)
        {
            
            float adder = Random.Range(3f, 10f) * (Random.Range(1, 2) % 2 == 0 ? -1f : 1f);
            Vector3 pos1 = new Vector3(20f + adder, -4, -1f * Random.Range(2f, 10f));
            
            adder = Random.Range(3f, 10f) * (Random.Range(1, 2) % 2 == 0 ? -1f : 1f);
            Vector3 pos2 = new Vector3(20f + adder, -4, Random.Range(4f, 18f));
            
            index = Random.Range(0, decorations.Length-1);
            
            GameObject newDecor = Instantiate(decorations[index], pos1, Quaternion.identity);
            newDecor.transform.SetParent(transform);
            newDecor.GameObject().transform.GetChild(0).rotation =
                Quaternion.Euler(0f, rotationAngles[Random.Range(0, rotationAngles.Length)], 0f);
            
            newDecor = Instantiate(decorations[index], pos2, Quaternion.identity);
            newDecor.transform.SetParent(transform);
            newDecor.GameObject().transform.GetChild(0).rotation =
                Quaternion.Euler(0f, rotationAngles[Random.Range(0, rotationAngles.Length)], 0f);
            //Quaternion.Euler(0f, rotationAngles[Random.Range(0, rotationAngles.Length)], 0f )
        }
    }
    
    private void UpdateSpeed()
    {
        speed = speedcntrl.speed;
    }
}
