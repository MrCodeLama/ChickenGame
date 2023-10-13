using UnityEngine;

public class EggBounce : MonoBehaviour
{
    public float minY = 0f; 
    public float maxY = 5f; 
    public float speed = 2f; 

    private bool goingUp = true;

    void Update()
    {
        if (goingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            if (transform.position.y >= maxY)
            {
                goingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (transform.position.y <= minY)
            {
                goingUp = true;
            }
        }
    }
}